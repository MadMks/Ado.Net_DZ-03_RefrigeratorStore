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

namespace Task_RefrigeratorStore
{
    public partial class MainForm : Form
    {
        private SqlConnection connection = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private SqlCommandBuilder commandBuilder = null;
        private string selectQuery = "";

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
                this.comboBoxSellers.DataSource = dataSet.Tables["sellers"];
                this.comboBoxSellers.DisplayMember = "LastName";
                //this.comboBoxSellers.ValueMember = "Seller_ID";

                // Customers
                this.comboBoxCustomers.DataSource = dataSet.Tables["customers"];
                this.comboBoxCustomers.DisplayMember = "LastName";

                // Goods
                this.listBoxGoods.DataSource = dataSet.Tables["goods"];
                this.listBoxGoods.DisplayMember = "Name";

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
    }
}
