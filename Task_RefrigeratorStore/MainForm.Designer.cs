﻿namespace Task_RefrigeratorStore
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxSellers = new System.Windows.Forms.ComboBox();
            this.comboBoxCustomers = new System.Windows.Forms.ComboBox();
            this.listBoxGoods = new System.Windows.Forms.ListBox();
            this.buttonCreateReceipt = new System.Windows.Forms.Button();
            this.dataGridViewReceipts = new System.Windows.Forms.DataGridView();
            this.labelSeller = new System.Windows.Forms.Label();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.labelGoods = new System.Windows.Forms.Label();
            this.labelReceipts = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceipts)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSellers
            // 
            this.comboBoxSellers.FormattingEnabled = true;
            this.comboBoxSellers.Location = new System.Drawing.Point(12, 32);
            this.comboBoxSellers.Name = "comboBoxSellers";
            this.comboBoxSellers.Size = new System.Drawing.Size(230, 21);
            this.comboBoxSellers.TabIndex = 0;
            // 
            // comboBoxCustomers
            // 
            this.comboBoxCustomers.FormattingEnabled = true;
            this.comboBoxCustomers.Location = new System.Drawing.Point(13, 80);
            this.comboBoxCustomers.Name = "comboBoxCustomers";
            this.comboBoxCustomers.Size = new System.Drawing.Size(229, 21);
            this.comboBoxCustomers.TabIndex = 1;
            // 
            // listBoxGoods
            // 
            this.listBoxGoods.FormattingEnabled = true;
            this.listBoxGoods.Location = new System.Drawing.Point(13, 129);
            this.listBoxGoods.Name = "listBoxGoods";
            this.listBoxGoods.Size = new System.Drawing.Size(229, 95);
            this.listBoxGoods.TabIndex = 2;
            // 
            // buttonCreateReceipt
            // 
            this.buttonCreateReceipt.Location = new System.Drawing.Point(12, 255);
            this.buttonCreateReceipt.Name = "buttonCreateReceipt";
            this.buttonCreateReceipt.Size = new System.Drawing.Size(230, 23);
            this.buttonCreateReceipt.TabIndex = 3;
            this.buttonCreateReceipt.Text = "Оформить продажу";
            this.buttonCreateReceipt.UseVisualStyleBackColor = true;
            // 
            // dataGridViewReceipts
            // 
            this.dataGridViewReceipts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReceipts.Location = new System.Drawing.Point(272, 32);
            this.dataGridViewReceipts.Name = "dataGridViewReceipts";
            this.dataGridViewReceipts.RowTemplate.Height = 23;
            this.dataGridViewReceipts.Size = new System.Drawing.Size(362, 246);
            this.dataGridViewReceipts.TabIndex = 4;
            // 
            // labelSeller
            // 
            this.labelSeller.AutoSize = true;
            this.labelSeller.Location = new System.Drawing.Point(13, 13);
            this.labelSeller.Name = "labelSeller";
            this.labelSeller.Size = new System.Drawing.Size(57, 13);
            this.labelSeller.TabIndex = 5;
            this.labelSeller.Text = "Продавец";
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Location = new System.Drawing.Point(14, 60);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(68, 13);
            this.labelCustomer.TabIndex = 6;
            this.labelCustomer.Text = "Покупатель";
            // 
            // labelGoods
            // 
            this.labelGoods.AutoSize = true;
            this.labelGoods.Location = new System.Drawing.Point(14, 111);
            this.labelGoods.Name = "labelGoods";
            this.labelGoods.Size = new System.Drawing.Size(45, 13);
            this.labelGoods.TabIndex = 7;
            this.labelGoods.Text = "Товары";
            // 
            // labelReceipts
            // 
            this.labelReceipts.AutoSize = true;
            this.labelReceipts.Location = new System.Drawing.Point(274, 13);
            this.labelReceipts.Name = "labelReceipts";
            this.labelReceipts.Size = new System.Drawing.Size(62, 13);
            this.labelReceipts.TabIndex = 8;
            this.labelReceipts.Text = "Квитанции";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelReceipts);
            this.Controls.Add(this.labelGoods);
            this.Controls.Add(this.labelCustomer);
            this.Controls.Add(this.labelSeller);
            this.Controls.Add(this.dataGridViewReceipts);
            this.Controls.Add(this.buttonCreateReceipt);
            this.Controls.Add(this.listBoxGoods);
            this.Controls.Add(this.comboBoxCustomers);
            this.Controls.Add(this.comboBoxSellers);
            this.Name = "MainForm";
            this.Text = "Магазин холодильников";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceipts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSellers;
        private System.Windows.Forms.ComboBox comboBoxCustomers;
        private System.Windows.Forms.ListBox listBoxGoods;
        private System.Windows.Forms.Button buttonCreateReceipt;
        private System.Windows.Forms.DataGridView dataGridViewReceipts;
        private System.Windows.Forms.Label labelSeller;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.Label labelGoods;
        private System.Windows.Forms.Label labelReceipts;
    }
}
