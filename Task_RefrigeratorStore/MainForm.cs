﻿using System;
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
        }

        private void FirstConnectionToTheDatabase()
        {
            try
            {
                this.connection = new SqlConnection();
                this.connection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["RefrigeratorStoreDBConnectString"]
                    .ConnectionString;

                // Query
                this.selectQuery = "SELECT * FROM sellers;"
                    + "SELECT * FROM customers;"
                    + "SELECT * FROM goods";
                // DataAdapter
                this.dataAdapter = new SqlDataAdapter(this.selectQuery, this.connection);
                // CommandBuilder
                this.commandBuilder = new SqlCommandBuilder(this.dataAdapter);
                // DataSet
                this.dataSet = new DataSet();

                this.dataAdapter.Fill(this.dataSet);

                this.dataGridViewReceipts.DataSource = dataSet.Tables["table"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
