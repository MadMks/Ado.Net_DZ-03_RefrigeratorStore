namespace Task_RefrigeratorStore
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
            this.labelPurchasedGoods = new System.Windows.Forms.Label();
            this.groupBoxCustomer = new System.Windows.Forms.GroupBox();
            this.textBoxPurchasedGoods = new System.Windows.Forms.TextBox();
            this.labelQuantityGoods = new System.Windows.Forms.Label();
            this.textBoxQuantityGoods = new System.Windows.Forms.TextBox();
            this.groupBoxGoods = new System.Windows.Forms.GroupBox();
            this.groupBoxSeller = new System.Windows.Forms.GroupBox();
            this.groupBoxReceipts = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceipts)).BeginInit();
            this.groupBoxCustomer.SuspendLayout();
            this.groupBoxGoods.SuspendLayout();
            this.groupBoxSeller.SuspendLayout();
            this.groupBoxReceipts.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxSellers
            // 
            this.comboBoxSellers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSellers.FormattingEnabled = true;
            this.comboBoxSellers.Location = new System.Drawing.Point(18, 26);
            this.comboBoxSellers.Name = "comboBoxSellers";
            this.comboBoxSellers.Size = new System.Drawing.Size(230, 21);
            this.comboBoxSellers.TabIndex = 0;
            // 
            // comboBoxCustomers
            // 
            this.comboBoxCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomers.FormattingEnabled = true;
            this.comboBoxCustomers.Location = new System.Drawing.Point(19, 28);
            this.comboBoxCustomers.Name = "comboBoxCustomers";
            this.comboBoxCustomers.Size = new System.Drawing.Size(229, 21);
            this.comboBoxCustomers.TabIndex = 1;
            this.comboBoxCustomers.SelectedIndexChanged += new System.EventHandler(this.comboBoxCustomers_SelectedIndexChanged);
            // 
            // listBoxGoods
            // 
            this.listBoxGoods.FormattingEnabled = true;
            this.listBoxGoods.Location = new System.Drawing.Point(19, 24);
            this.listBoxGoods.Name = "listBoxGoods";
            this.listBoxGoods.Size = new System.Drawing.Size(229, 95);
            this.listBoxGoods.TabIndex = 2;
            this.listBoxGoods.SelectedIndexChanged += new System.EventHandler(this.listBoxGoods_SelectedIndexChanged);
            // 
            // buttonCreateReceipt
            // 
            this.buttonCreateReceipt.Location = new System.Drawing.Point(144, 209);
            this.buttonCreateReceipt.Name = "buttonCreateReceipt";
            this.buttonCreateReceipt.Size = new System.Drawing.Size(287, 58);
            this.buttonCreateReceipt.TabIndex = 3;
            this.buttonCreateReceipt.Text = "Оформить продажу";
            this.buttonCreateReceipt.UseVisualStyleBackColor = true;
            this.buttonCreateReceipt.Click += new System.EventHandler(this.buttonCreateReceipt_Click);
            // 
            // dataGridViewReceipts
            // 
            this.dataGridViewReceipts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReceipts.Location = new System.Drawing.Point(18, 28);
            this.dataGridViewReceipts.Name = "dataGridViewReceipts";
            this.dataGridViewReceipts.ReadOnly = true;
            this.dataGridViewReceipts.RowTemplate.Height = 23;
            this.dataGridViewReceipts.Size = new System.Drawing.Size(512, 239);
            this.dataGridViewReceipts.TabIndex = 4;
            // 
            // labelPurchasedGoods
            // 
            this.labelPurchasedGoods.AutoSize = true;
            this.labelPurchasedGoods.Location = new System.Drawing.Point(16, 68);
            this.labelPurchasedGoods.Name = "labelPurchasedGoods";
            this.labelPurchasedGoods.Size = new System.Drawing.Size(99, 13);
            this.labelPurchasedGoods.TabIndex = 9;
            this.labelPurchasedGoods.Text = "Куплено товаров:";
            // 
            // groupBoxCustomer
            // 
            this.groupBoxCustomer.Controls.Add(this.textBoxPurchasedGoods);
            this.groupBoxCustomer.Controls.Add(this.labelPurchasedGoods);
            this.groupBoxCustomer.Controls.Add(this.comboBoxCustomers);
            this.groupBoxCustomer.Location = new System.Drawing.Point(14, 84);
            this.groupBoxCustomer.Name = "groupBoxCustomer";
            this.groupBoxCustomer.Size = new System.Drawing.Size(267, 100);
            this.groupBoxCustomer.TabIndex = 10;
            this.groupBoxCustomer.TabStop = false;
            this.groupBoxCustomer.Text = "Покупатель";
            // 
            // textBoxPurchasedGoods
            // 
            this.textBoxPurchasedGoods.Location = new System.Drawing.Point(122, 64);
            this.textBoxPurchasedGoods.Name = "textBoxPurchasedGoods";
            this.textBoxPurchasedGoods.ReadOnly = true;
            this.textBoxPurchasedGoods.Size = new System.Drawing.Size(126, 21);
            this.textBoxPurchasedGoods.TabIndex = 10;
            // 
            // labelQuantityGoods
            // 
            this.labelQuantityGoods.AutoSize = true;
            this.labelQuantityGoods.Location = new System.Drawing.Point(19, 139);
            this.labelQuantityGoods.Name = "labelQuantityGoods";
            this.labelQuantityGoods.Size = new System.Drawing.Size(46, 13);
            this.labelQuantityGoods.TabIndex = 11;
            this.labelQuantityGoods.Text = "Кол-во:";
            // 
            // textBoxQuantityGoods
            // 
            this.textBoxQuantityGoods.Location = new System.Drawing.Point(71, 135);
            this.textBoxQuantityGoods.Name = "textBoxQuantityGoods";
            this.textBoxQuantityGoods.ReadOnly = true;
            this.textBoxQuantityGoods.Size = new System.Drawing.Size(177, 21);
            this.textBoxQuantityGoods.TabIndex = 11;
            // 
            // groupBoxGoods
            // 
            this.groupBoxGoods.Controls.Add(this.listBoxGoods);
            this.groupBoxGoods.Controls.Add(this.textBoxQuantityGoods);
            this.groupBoxGoods.Controls.Add(this.labelQuantityGoods);
            this.groupBoxGoods.Location = new System.Drawing.Point(296, 13);
            this.groupBoxGoods.Name = "groupBoxGoods";
            this.groupBoxGoods.Size = new System.Drawing.Size(267, 172);
            this.groupBoxGoods.TabIndex = 12;
            this.groupBoxGoods.TabStop = false;
            this.groupBoxGoods.Text = "Товары";
            // 
            // groupBoxSeller
            // 
            this.groupBoxSeller.Controls.Add(this.comboBoxSellers);
            this.groupBoxSeller.Location = new System.Drawing.Point(14, 13);
            this.groupBoxSeller.Name = "groupBoxSeller";
            this.groupBoxSeller.Size = new System.Drawing.Size(267, 65);
            this.groupBoxSeller.TabIndex = 13;
            this.groupBoxSeller.TabStop = false;
            this.groupBoxSeller.Text = "Продавец";
            // 
            // groupBoxReceipts
            // 
            this.groupBoxReceipts.Controls.Add(this.dataGridViewReceipts);
            this.groupBoxReceipts.Location = new System.Drawing.Point(14, 288);
            this.groupBoxReceipts.Name = "groupBoxReceipts";
            this.groupBoxReceipts.Size = new System.Drawing.Size(549, 287);
            this.groupBoxReceipts.TabIndex = 14;
            this.groupBoxReceipts.TabStop = false;
            this.groupBoxReceipts.Text = "Квитанции";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 587);
            this.Controls.Add(this.groupBoxReceipts);
            this.Controls.Add(this.groupBoxSeller);
            this.Controls.Add(this.groupBoxGoods);
            this.Controls.Add(this.groupBoxCustomer);
            this.Controls.Add(this.buttonCreateReceipt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Магазин холодильников";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceipts)).EndInit();
            this.groupBoxCustomer.ResumeLayout(false);
            this.groupBoxCustomer.PerformLayout();
            this.groupBoxGoods.ResumeLayout(false);
            this.groupBoxGoods.PerformLayout();
            this.groupBoxSeller.ResumeLayout(false);
            this.groupBoxReceipts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSellers;
        private System.Windows.Forms.ComboBox comboBoxCustomers;
        private System.Windows.Forms.ListBox listBoxGoods;
        private System.Windows.Forms.Button buttonCreateReceipt;
        private System.Windows.Forms.DataGridView dataGridViewReceipts;
        private System.Windows.Forms.Label labelPurchasedGoods;
        private System.Windows.Forms.GroupBox groupBoxCustomer;
        private System.Windows.Forms.TextBox textBoxPurchasedGoods;
        private System.Windows.Forms.Label labelQuantityGoods;
        private System.Windows.Forms.TextBox textBoxQuantityGoods;
        private System.Windows.Forms.GroupBox groupBoxGoods;
        private System.Windows.Forms.GroupBox groupBoxSeller;
        private System.Windows.Forms.GroupBox groupBoxReceipts;
    }
}

