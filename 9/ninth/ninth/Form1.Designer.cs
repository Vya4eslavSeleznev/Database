namespace ninth
{
  partial class Form1
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
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.City = new System.Windows.Forms.TextBox();
      this.Country = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.Insert = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.Phone = new System.Windows.Forms.TextBox();
      this.ContactName = new System.Windows.Forms.TextBox();
      this.CompanyName = new System.Windows.Forms.TextBox();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.cbSV = new System.Windows.Forms.ComboBox();
      this.cbEID = new System.Windows.Forms.ComboBox();
      this.cbCID = new System.Windows.Forms.ComboBox();
      this.dgOD = new System.Windows.Forms.DataGridView();
      this.productIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.unitPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.discountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dsOD = new ninth.dsOrderDetails();
      this.addButton = new System.Windows.Forms.Button();
      this.textBox5 = new System.Windows.Forms.TextBox();
      this.OrderDate = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.cn = new System.Data.OleDb.OleDbConnection();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgOD)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dsOD)).BeginInit();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(803, 449);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.City);
      this.tabPage1.Controls.Add(this.Country);
      this.tabPage1.Controls.Add(this.label5);
      this.tabPage1.Controls.Add(this.label1);
      this.tabPage1.Controls.Add(this.Insert);
      this.tabPage1.Controls.Add(this.label4);
      this.tabPage1.Controls.Add(this.label3);
      this.tabPage1.Controls.Add(this.label2);
      this.tabPage1.Controls.Add(this.Phone);
      this.tabPage1.Controls.Add(this.ContactName);
      this.tabPage1.Controls.Add(this.CompanyName);
      this.tabPage1.Location = new System.Drawing.Point(4, 25);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(795, 420);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Add Customer";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // City
      // 
      this.City.Location = new System.Drawing.Point(213, 204);
      this.City.Name = "City";
      this.City.Size = new System.Drawing.Size(405, 22);
      this.City.TabIndex = 12;
      // 
      // Country
      // 
      this.Country.Location = new System.Drawing.Point(213, 161);
      this.Country.Name = "Country";
      this.Country.Size = new System.Drawing.Size(404, 22);
      this.Country.TabIndex = 11;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(37, 209);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(35, 17);
      this.label5.TabIndex = 10;
      this.label5.Text = "City:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(37, 161);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(61, 17);
      this.label1.TabIndex = 9;
      this.label1.Text = "Country:";
      // 
      // Insert
      // 
      this.Insert.Location = new System.Drawing.Point(40, 240);
      this.Insert.Name = "Insert";
      this.Insert.Size = new System.Drawing.Size(578, 30);
      this.Insert.TabIndex = 8;
      this.Insert.Text = "Insert";
      this.Insert.UseVisualStyleBackColor = true;
      this.Insert.Click += new System.EventHandler(this.Insert_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(37, 116);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(53, 17);
      this.label4.TabIndex = 7;
      this.label4.Text = "Phone:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(37, 72);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(101, 17);
      this.label3.TabIndex = 6;
      this.label3.Text = "Contact Name:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(37, 28);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(112, 17);
      this.label2.TabIndex = 5;
      this.label2.Text = "Company Name:";
      // 
      // Phone
      // 
      this.Phone.Location = new System.Drawing.Point(213, 116);
      this.Phone.Name = "Phone";
      this.Phone.Size = new System.Drawing.Size(405, 22);
      this.Phone.TabIndex = 3;
      // 
      // ContactName
      // 
      this.ContactName.Location = new System.Drawing.Point(213, 72);
      this.ContactName.Name = "ContactName";
      this.ContactName.Size = new System.Drawing.Size(405, 22);
      this.ContactName.TabIndex = 2;
      // 
      // CompanyName
      // 
      this.CompanyName.Location = new System.Drawing.Point(212, 28);
      this.CompanyName.Name = "CompanyName";
      this.CompanyName.Size = new System.Drawing.Size(406, 22);
      this.CompanyName.TabIndex = 1;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.cbSV);
      this.tabPage2.Controls.Add(this.cbEID);
      this.tabPage2.Controls.Add(this.cbCID);
      this.tabPage2.Controls.Add(this.dgOD);
      this.tabPage2.Controls.Add(this.addButton);
      this.tabPage2.Controls.Add(this.textBox5);
      this.tabPage2.Controls.Add(this.OrderDate);
      this.tabPage2.Controls.Add(this.label10);
      this.tabPage2.Controls.Add(this.label9);
      this.tabPage2.Controls.Add(this.label8);
      this.tabPage2.Controls.Add(this.label7);
      this.tabPage2.Controls.Add(this.label6);
      this.tabPage2.Location = new System.Drawing.Point(4, 25);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(795, 420);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Add Order";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // cbSV
      // 
      this.cbSV.FormattingEnabled = true;
      this.cbSV.Location = new System.Drawing.Point(171, 115);
      this.cbSV.Name = "cbSV";
      this.cbSV.Size = new System.Drawing.Size(201, 24);
      this.cbSV.TabIndex = 14;
      // 
      // cbEID
      // 
      this.cbEID.FormattingEnabled = true;
      this.cbEID.Location = new System.Drawing.Point(171, 68);
      this.cbEID.Name = "cbEID";
      this.cbEID.Size = new System.Drawing.Size(201, 24);
      this.cbEID.TabIndex = 13;
      // 
      // cbCID
      // 
      this.cbCID.FormattingEnabled = true;
      this.cbCID.Location = new System.Drawing.Point(171, 20);
      this.cbCID.Name = "cbCID";
      this.cbCID.Size = new System.Drawing.Size(201, 24);
      this.cbCID.TabIndex = 12;
      // 
      // dgOD
      // 
      this.dgOD.AutoGenerateColumns = false;
      this.dgOD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgOD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productIDDataGridViewTextBoxColumn,
            this.unitPriceDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.discountDataGridViewTextBoxColumn});
      this.dgOD.DataMember = "OrderDetails";
      this.dgOD.DataSource = this.dsOD;
      this.dgOD.Location = new System.Drawing.Point(8, 148);
      this.dgOD.Name = "dgOD";
      this.dgOD.RowHeadersWidth = 51;
      this.dgOD.RowTemplate.Height = 24;
      this.dgOD.Size = new System.Drawing.Size(776, 271);
      this.dgOD.TabIndex = 11;
      // 
      // productIDDataGridViewTextBoxColumn
      // 
      this.productIDDataGridViewTextBoxColumn.DataPropertyName = "ProductID";
      this.productIDDataGridViewTextBoxColumn.HeaderText = "ProductID";
      this.productIDDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.productIDDataGridViewTextBoxColumn.Name = "productIDDataGridViewTextBoxColumn";
      this.productIDDataGridViewTextBoxColumn.Width = 125;
      // 
      // unitPriceDataGridViewTextBoxColumn
      // 
      this.unitPriceDataGridViewTextBoxColumn.DataPropertyName = "UnitPrice";
      this.unitPriceDataGridViewTextBoxColumn.HeaderText = "UnitPrice";
      this.unitPriceDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.unitPriceDataGridViewTextBoxColumn.Name = "unitPriceDataGridViewTextBoxColumn";
      this.unitPriceDataGridViewTextBoxColumn.Width = 125;
      // 
      // quantityDataGridViewTextBoxColumn
      // 
      this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
      this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
      this.quantityDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
      this.quantityDataGridViewTextBoxColumn.Width = 125;
      // 
      // discountDataGridViewTextBoxColumn
      // 
      this.discountDataGridViewTextBoxColumn.DataPropertyName = "Discount";
      this.discountDataGridViewTextBoxColumn.HeaderText = "Discount";
      this.discountDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.discountDataGridViewTextBoxColumn.Name = "discountDataGridViewTextBoxColumn";
      this.discountDataGridViewTextBoxColumn.Width = 125;
      // 
      // dsOD
      // 
      this.dsOD.DataSetName = "dsOrderDetails";
      this.dsOD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // addButton
      // 
      this.addButton.Location = new System.Drawing.Point(470, 99);
      this.addButton.Name = "addButton";
      this.addButton.Size = new System.Drawing.Size(303, 40);
      this.addButton.TabIndex = 10;
      this.addButton.Text = "Add";
      this.addButton.UseVisualStyleBackColor = true;
      this.addButton.Click += new System.EventHandler(this.addButton_Click);
      // 
      // textBox5
      // 
      this.textBox5.Location = new System.Drawing.Point(572, 71);
      this.textBox5.Name = "textBox5";
      this.textBox5.Size = new System.Drawing.Size(201, 22);
      this.textBox5.TabIndex = 9;
      // 
      // OrderDate
      // 
      this.OrderDate.Location = new System.Drawing.Point(572, 22);
      this.OrderDate.Name = "OrderDate";
      this.OrderDate.Size = new System.Drawing.Size(201, 22);
      this.OrderDate.TabIndex = 8;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(467, 71);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(76, 17);
      this.label10.TabIndex = 4;
      this.label10.Text = "Ship Price:";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(467, 27);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(83, 17);
      this.label9.TabIndex = 3;
      this.label9.Text = "Order Date:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(21, 117);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(64, 17);
      this.label8.TabIndex = 2;
      this.label8.Text = "Ship Via:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(21, 71);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(84, 17);
      this.label7.TabIndex = 1;
      this.label7.Text = "Emploee ID:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(21, 27);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(89, 17);
      this.label6.TabIndex = 0;
      this.label6.Text = "Customer ID:";
      // 
      // cn
      // 
      this.cn.ConnectionString = "Provider=SQLNCLI11;Data Source=LAPTOP-V75FG2GF\\SQLEXPRESS;Integrated Security=SSP" +
    "I;Initial Catalog=Company";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.tabControl1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgOD)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dsOD)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox Phone;
    private System.Windows.Forms.Button Insert;
    private System.Data.OleDb.OleDbConnection cn;
    private System.Windows.Forms.TextBox City;
    private System.Windows.Forms.TextBox Country;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox5;
    private System.Windows.Forms.TextBox OrderDate;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button addButton;
    private System.Windows.Forms.DataGridView dgOD;
    private System.Windows.Forms.TextBox ContactName;
    private System.Windows.Forms.TextBox CompanyName;
    private System.Windows.Forms.ComboBox cbSV;
    private System.Windows.Forms.ComboBox cbEID;
    private System.Windows.Forms.ComboBox cbCID;
    private dsOrderDetails dsOD;
    private System.Windows.Forms.DataGridViewTextBoxColumn productIDDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn unitPriceDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn discountDataGridViewTextBoxColumn;
  }
}

