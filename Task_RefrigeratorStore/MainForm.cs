using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Common;
using System.Globalization;

namespace Task_RefrigeratorStore
{
    public partial class MainForm : Form
    {
        private SqlConnection connection = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private SqlCommandBuilder commandBuilder = null;
        private string selectQuery = "";

        private object selectedSeller;
        private object selectedCustomer;
        private object selectedGoods;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FirstConnectionToTheDatabase();
            this.LoadingDataIntoVisualElements();
        }

        private void LoadingDataIntoVisualElements()
        {
            try
            {
                // Sellers
                this.comboBoxSellers.DisplayMember = "LastName";
                this.comboBoxSellers.ValueMember = "Seller_ID";
                this.comboBoxSellers.DataSource = dataSet.Tables["sellers"];
                

                // Customers
                this.comboBoxCustomers.DisplayMember = "LastName";
                this.comboBoxCustomers.ValueMember = "Customer_ID";
                this.comboBoxCustomers.DataSource = dataSet.Tables["customers"];


                // Goods
                this.listBoxGoods.DisplayMember = "Name";
                this.listBoxGoods.ValueMember = "Goods_ID";
                this.listBoxGoods.DataSource = dataSet.Tables["goods"];
                

                this.dataGridViewReceipts.DataSource = dataSet.Tables["sales_receipts"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FirstConnectionToTheDatabase()
        {
            try
            {
                // Connection
                this.connection = new SqlConnection();
                this.connection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["RefrigeratorStoreDBConnectString"]
                    .ConnectionString;
                // Query
                this.selectQuery = "SELECT * FROM sellers;"
                    + "SELECT * FROM customers;"
                    + "SELECT * FROM goods;"
                    + "SELECT * FROM sales_receipts";
                // DataAdapter
                this.dataAdapter = new SqlDataAdapter(this.selectQuery, this.connection);
                this.SettingUpDisplayOfTableNames(this.dataAdapter);
                // CommandBuilder
                this.commandBuilder = new SqlCommandBuilder(this.dataAdapter);
                // DataSet
                this.dataSet = new DataSet();
                // Fill
                this.dataAdapter.Fill(this.dataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Настройка отображения имен таблиц.
        /// </summary>
        /// <param name="dataAdapter">Объект dataAdapter</param>
        private void SettingUpDisplayOfTableNames(SqlDataAdapter dataAdapter)
        {
            this.dataAdapter.TableMappings.Add("Table", "sellers");
            this.dataAdapter.TableMappings.Add("Table1", "customers");
            this.dataAdapter.TableMappings.Add("Table2", "goods");

            DataTableMapping tableMapping_Sales
                = this.dataAdapter.TableMappings.Add("Table3", "sales_receipts");
            tableMapping_Sales.ColumnMappings.Add("Receipt_ID", "Номер чека");
            tableMapping_Sales.ColumnMappings.Add("DateOfsale", "Номер продажи");
            tableMapping_Sales.ColumnMappings.Add("FullNameCustomer", "ФИО покупателя");
            tableMapping_Sales.ColumnMappings.Add("FullNameSeller", "ФИО продавца");
            tableMapping_Sales.ColumnMappings.Add("ProductName", "Купленные позиции");
        }

        private void buttonCreateReceipt_Click(object sender, EventArgs e)
        {
            SqlCommand command = null;
            SqlTransaction transaction = null;

            try
            {
                this.connection.Open();
                transaction = this.connection.BeginTransaction();
                command = this.connection.CreateCommand();
                command.Transaction = transaction;

                // Вставка данных в таблицу квитанций.
                command.CommandText = this.GetStringOfDataInsertionInTheCheckStorageTable();
                command.ExecuteNonQuery();

                // Снятие с остатков на складе.
                this.WriteOffOfGoodsFromStock(command);

                // Добавление кол-ва к купленным товарам покупателя.
                command.CommandText = this.GetStringOfAdditionToPurchasedGoodsOfBuyer();
                command.ExecuteNonQuery();

                transaction.Commit();

                this.UpdatingTheDataInTheProgram();

            }
            catch (NoProductsException ex)
            {
                MessageBox.Show(ex.Message);

                transaction.Rollback();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
                transaction.Rollback();
            }
            finally
            {
                this.connection?.Close();
            }
        }

        /// <summary>
        /// Списание товаров со склада.
        /// </summary>
        /// <param name="command">Обьект SqlCommand</param>
        private void WriteOffOfGoodsFromStock(SqlCommand command)
        {
            command.CommandText = this.GetStringOfWriteOffFromStorage();
            if (this.GetQuantitySelectedGoods() == 0)
            {
                throw new NoProductsException();
            }
            else
            {
                command.ExecuteNonQuery();  // в таблице (дополнительно) добавлено ограничение (Quantity >= 0).
            }
        }

        private int GetQuantitySelectedGoods()
        {
            string filterString =
                "Goods_ID = "
                + this.listBoxGoods.SelectedValue.ToString();

            DataRow dataRow = this.dataSet.Tables["goods"].Select(filterString)[0];

            return Convert.ToInt32(dataRow[2]);
        }

        /// <summary>
        /// Получить строку запроса добавления кол-ва купленного товара покупателю.
        /// (в данной версии программы можно купить товар в кол-ве 1 шт).
        /// </summary>
        /// <returns>строка запроса добавления покупателя кол-ва купленных товаров.</returns>
        private string GetStringOfAdditionToPurchasedGoodsOfBuyer()
        {
            string insertString = @"UPDATE customers SET PurchasedGoods = PurchasedGoods + 1
                WHERE Customer_ID = " + this.comboBoxCustomers.SelectedValue.ToString();

            return insertString;
        }

        /// <summary>
        /// Получить строку запроса снятия кол-ва товаров с склада.
        /// </summary>
        /// <returns>Строка запроса списания выбранного товара с склада.</returns>
        private string GetStringOfWriteOffFromStorage()
        {
            string insertString = @"UPDATE goods SET Quantity = Quantity - 1
                WHERE Goods_ID = " + this.listBoxGoods.SelectedValue.ToString();
                //+ " AND Quantity > 0";

            return insertString;
        }

        /// <summary>
        /// Обновляем данные в программе.
        /// </summary>
        private void UpdatingTheDataInTheProgram()
        {
            this.RememberTheSelectedPurchaseSettings();

            (this.comboBoxSellers.DataSource as DataTable).Clear();
            (this.comboBoxCustomers.DataSource as DataTable).Clear();
            (this.listBoxGoods.DataSource as DataTable).Clear();
            (this.dataGridViewReceipts.DataSource as DataTable).Clear();
            this.dataAdapter.Fill(this.dataSet);

            this.RestoreSelectedPurchaseSettings();

            this.UpdateTextBoxQuantityData();
        }

        /// <summary>
        /// Обновленние измененных данных в текстБоксах кол-ва товаров.
        /// </summary>
        private void UpdateTextBoxQuantityData()
        {
            this.UpdateTextBoxPurchasedGoods();
            this.UpdateTextBoxQuantityGoods();
        }

        /// <summary>
        /// Восстановить выбранные настройки покупки.
        /// </summary>
        private void RestoreSelectedPurchaseSettings()
        {
            this.comboBoxSellers.SelectedValue = this.selectedSeller;
            this.comboBoxCustomers.SelectedValue = this.selectedCustomer;
            this.listBoxGoods.SelectedValue = this.selectedGoods;
        }

        /// <summary>
        /// Запоминаем выбранные настройки покупки (оформления чека).
        /// </summary>
        private void RememberTheSelectedPurchaseSettings()
        {
            this.selectedSeller = this.comboBoxSellers.SelectedValue;
            this.selectedCustomer = this.comboBoxCustomers.SelectedValue;
            this.selectedGoods = this.listBoxGoods.SelectedValue;
        }

        /// <summary>
        /// Получить строку запроса вставки данных
        /// в таблицу хранения чеков.
        /// </summary>
        /// <returns>Строка запроса вставки данных в таблицу.</returns>
        private string GetStringOfDataInsertionInTheCheckStorageTable()
        {
            string insertQuery = @"INSERT INTO sales_receipts"
                + " ([DateOfsale], [FullNameCustomer], [FullNameSeller], [ProductName])"
                + " VALUES"
                + " ( '" + DateTime.Today.Date.ToString("yyyyMM" +
                "dd"/*, new CultureInfo("en-US")*/) + "', '"
                    + this.GetFullNameSelectedCustomer() + "', '"
                    + this.GetFullNameSelectedSeller() + "', '"
                    + this.GetNameSelectedProduct() + "');";

            return insertQuery;
        }

        private string GetNameSelectedProduct()
        {
            string filterString
                = "Goods_ID = '"
                + this.listBoxGoods.SelectedValue
                + "'";

            DataRow dataRow = this.dataSet.Tables["goods"].Select(filterString)[0];

            return dataRow[1].ToString();
        }

        private string GetFullNameSelectedSeller()
        {
            string filterString
                = "Seller_ID = '"
                + this.comboBoxSellers.SelectedValue
                + "'";

            DataRow dataRow = this.dataSet.Tables["sellers"].Select(filterString)[0];

            return dataRow[1].ToString() + " "
                + dataRow[2].ToString() + " "
                + dataRow[3].ToString();
        }

        private string GetFullNameSelectedCustomer()
        {
            string filterString
                = "Customer_ID = '"
                + this.comboBoxCustomers.SelectedValue
                + "'";

            DataRow dataRow = this.dataSet.Tables["customers"].Select(filterString)[0];

            return dataRow[1].ToString() + " "
                + dataRow[2].ToString() + " "
                + dataRow[3].ToString();
        }

        private void comboBoxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateTextBoxPurchasedGoods();
        }

        /// <summary>
        /// Обновить TextBox кол-во приобретенных товаров. 
        /// </summary>
        private void UpdateTextBoxPurchasedGoods()
        {
            string filterString
                = "Customer_ID = '"
                + this.comboBoxCustomers.SelectedValue
                + "'";

            this.textBoxPurchasedGoods.Text = this.dataSet.Tables["customers"].Select(filterString)[0][4].ToString();
        }

        private void listBoxGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateTextBoxQuantityGoods();
        }

        /// <summary>
        /// Обновить TextBox кол-во товаров.
        /// </summary>
        private void UpdateTextBoxQuantityGoods()
        {
            string filterString
                = "Goods_ID = '"
                + this.listBoxGoods.SelectedValue
                + "'";

            this.textBoxQuantityGoods.Text = this.dataSet.Tables["goods"].Select(filterString)[0][2].ToString();
        }
    }
}
