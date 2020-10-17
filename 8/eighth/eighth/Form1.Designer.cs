namespace eighth
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
      this.lastButton = new System.Windows.Forms.Button();
      this.firstButton = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.ShipCountry = new System.Windows.Forms.TextBox();
      this.ShipCity = new System.Windows.Forms.TextBox();
      this.ShipName = new System.Windows.Forms.TextBox();
      this.CustomerID = new System.Windows.Forms.TextBox();
      this.OrderID = new System.Windows.Forms.TextBox();
      this.nextButton = new System.Windows.Forms.Button();
      this.BackButton = new System.Windows.Forms.Button();
      this.showButton = new System.Windows.Forms.Button();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.dgOrderDetails = new System.Windows.Forms.DataGridView();
      this.showOrderDetailsButton = new System.Windows.Forms.Button();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.dgCategories = new System.Windows.Forms.DataGridView();
      this.addButton = new System.Windows.Forms.Button();
      this.Description = new System.Windows.Forms.TextBox();
      this.CategoryName = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.cn = new System.Data.OleDb.OleDbConnection();
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgOrderDetails)).BeginInit();
      this.tabPage3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgCategories)).BeginInit();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage3);
      this.tabControl1.Location = new System.Drawing.Point(11, 5);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(788, 445);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.lastButton);
      this.tabPage1.Controls.Add(this.firstButton);
      this.tabPage1.Controls.Add(this.label5);
      this.tabPage1.Controls.Add(this.label4);
      this.tabPage1.Controls.Add(this.label3);
      this.tabPage1.Controls.Add(this.label2);
      this.tabPage1.Controls.Add(this.label1);
      this.tabPage1.Controls.Add(this.ShipCountry);
      this.tabPage1.Controls.Add(this.ShipCity);
      this.tabPage1.Controls.Add(this.ShipName);
      this.tabPage1.Controls.Add(this.CustomerID);
      this.tabPage1.Controls.Add(this.OrderID);
      this.tabPage1.Controls.Add(this.nextButton);
      this.tabPage1.Controls.Add(this.BackButton);
      this.tabPage1.Controls.Add(this.showButton);
      this.tabPage1.Location = new System.Drawing.Point(4, 25);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(780, 416);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Orders";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // lastButton
      // 
      this.lastButton.Location = new System.Drawing.Point(407, 303);
      this.lastButton.Name = "lastButton";
      this.lastButton.Size = new System.Drawing.Size(297, 37);
      this.lastButton.TabIndex = 14;
      this.lastButton.Text = "Last";
      this.lastButton.UseVisualStyleBackColor = true;
      this.lastButton.Click += new System.EventHandler(this.lastButton_Click);
      // 
      // firstButton
      // 
      this.firstButton.Location = new System.Drawing.Point(22, 303);
      this.firstButton.Name = "firstButton";
      this.firstButton.Size = new System.Drawing.Size(297, 37);
      this.firstButton.TabIndex = 13;
      this.firstButton.Text = "First";
      this.firstButton.UseVisualStyleBackColor = true;
      this.firstButton.Click += new System.EventHandler(this.firstButton_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(150, 261);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(93, 17);
      this.label5.TabIndex = 12;
      this.label5.Text = "Ship Country:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(150, 216);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(67, 17);
      this.label4.TabIndex = 11;
      this.label4.Text = "Ship City:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(150, 168);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(81, 17);
      this.label3.TabIndex = 10;
      this.label3.Text = "Ship Name:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(150, 120);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(87, 17);
      this.label2.TabIndex = 9;
      this.label2.Text = "Customer Id:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(150, 73);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(64, 17);
      this.label1.TabIndex = 8;
      this.label1.Text = "Order Id:";
      // 
      // ShipCountry
      // 
      this.ShipCountry.Location = new System.Drawing.Point(296, 261);
      this.ShipCountry.Name = "ShipCountry";
      this.ShipCountry.Size = new System.Drawing.Size(409, 22);
      this.ShipCountry.TabIndex = 7;
      // 
      // ShipCity
      // 
      this.ShipCity.Location = new System.Drawing.Point(296, 216);
      this.ShipCity.Name = "ShipCity";
      this.ShipCity.Size = new System.Drawing.Size(409, 22);
      this.ShipCity.TabIndex = 6;
      // 
      // ShipName
      // 
      this.ShipName.Location = new System.Drawing.Point(296, 168);
      this.ShipName.Name = "ShipName";
      this.ShipName.Size = new System.Drawing.Size(409, 22);
      this.ShipName.TabIndex = 5;
      // 
      // CustomerID
      // 
      this.CustomerID.Location = new System.Drawing.Point(296, 120);
      this.CustomerID.Name = "CustomerID";
      this.CustomerID.Size = new System.Drawing.Size(409, 22);
      this.CustomerID.TabIndex = 4;
      // 
      // OrderID
      // 
      this.OrderID.Location = new System.Drawing.Point(295, 73);
      this.OrderID.Name = "OrderID";
      this.OrderID.Size = new System.Drawing.Size(409, 22);
      this.OrderID.TabIndex = 3;
      // 
      // nextButton
      // 
      this.nextButton.Location = new System.Drawing.Point(407, 371);
      this.nextButton.Name = "nextButton";
      this.nextButton.Size = new System.Drawing.Size(298, 37);
      this.nextButton.TabIndex = 2;
      this.nextButton.Text = "Next";
      this.nextButton.UseVisualStyleBackColor = true;
      this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
      // 
      // BackButton
      // 
      this.BackButton.Location = new System.Drawing.Point(21, 371);
      this.BackButton.Name = "BackButton";
      this.BackButton.Size = new System.Drawing.Size(298, 37);
      this.BackButton.TabIndex = 1;
      this.BackButton.Text = "Back";
      this.BackButton.UseVisualStyleBackColor = true;
      this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
      // 
      // showButton
      // 
      this.showButton.Location = new System.Drawing.Point(21, 19);
      this.showButton.Name = "showButton";
      this.showButton.Size = new System.Drawing.Size(684, 37);
      this.showButton.TabIndex = 0;
      this.showButton.Text = "Show";
      this.showButton.UseVisualStyleBackColor = true;
      this.showButton.Click += new System.EventHandler(this.showButton_Click);
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.dgOrderDetails);
      this.tabPage2.Controls.Add(this.showOrderDetailsButton);
      this.tabPage2.Location = new System.Drawing.Point(4, 25);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(780, 416);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Order details";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // dgOrderDetails
      // 
      this.dgOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgOrderDetails.Location = new System.Drawing.Point(19, 72);
      this.dgOrderDetails.Name = "dgOrderDetails";
      this.dgOrderDetails.RowHeadersWidth = 51;
      this.dgOrderDetails.RowTemplate.Height = 24;
      this.dgOrderDetails.Size = new System.Drawing.Size(737, 336);
      this.dgOrderDetails.TabIndex = 1;
      // 
      // showOrderDetailsButton
      // 
      this.showOrderDetailsButton.Location = new System.Drawing.Point(19, 13);
      this.showOrderDetailsButton.Name = "showOrderDetailsButton";
      this.showOrderDetailsButton.Size = new System.Drawing.Size(146, 37);
      this.showOrderDetailsButton.TabIndex = 0;
      this.showOrderDetailsButton.Text = "Show";
      this.showOrderDetailsButton.UseVisualStyleBackColor = true;
      this.showOrderDetailsButton.Click += new System.EventHandler(this.showOrderDetailsButton_Click);
      // 
      // tabPage3
      // 
      this.tabPage3.Controls.Add(this.dgCategories);
      this.tabPage3.Controls.Add(this.addButton);
      this.tabPage3.Controls.Add(this.Description);
      this.tabPage3.Controls.Add(this.CategoryName);
      this.tabPage3.Controls.Add(this.label7);
      this.tabPage3.Controls.Add(this.label6);
      this.tabPage3.Location = new System.Drawing.Point(4, 25);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new System.Drawing.Size(780, 416);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Categories";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // dgCategories
      // 
      this.dgCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgCategories.Location = new System.Drawing.Point(12, 107);
      this.dgCategories.Name = "dgCategories";
      this.dgCategories.RowHeadersWidth = 51;
      this.dgCategories.RowTemplate.Height = 24;
      this.dgCategories.Size = new System.Drawing.Size(758, 298);
      this.dgCategories.TabIndex = 5;
      // 
      // addButton
      // 
      this.addButton.Location = new System.Drawing.Point(287, 70);
      this.addButton.Name = "addButton";
      this.addButton.Size = new System.Drawing.Size(357, 24);
      this.addButton.TabIndex = 4;
      this.addButton.Text = "Add";
      this.addButton.UseVisualStyleBackColor = true;
      this.addButton.Click += new System.EventHandler(this.addButton_Click);
      // 
      // Description
      // 
      this.Description.Location = new System.Drawing.Point(287, 42);
      this.Description.Name = "Description";
      this.Description.Size = new System.Drawing.Size(357, 22);
      this.Description.TabIndex = 3;
      // 
      // CategoryName
      // 
      this.CategoryName.Location = new System.Drawing.Point(287, 14);
      this.CategoryName.Name = "CategoryName";
      this.CategoryName.Size = new System.Drawing.Size(357, 22);
      this.CategoryName.TabIndex = 2;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(79, 47);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(83, 17);
      this.label7.TabIndex = 1;
      this.label7.Text = "Description:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(79, 14);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(110, 17);
      this.label6.TabIndex = 0;
      this.label6.Text = "Category Name:";
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
      ((System.ComponentModel.ISupportInitialize)(this.dgOrderDetails)).EndInit();
      this.tabPage3.ResumeLayout(false);
      this.tabPage3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgCategories)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox ShipCountry;
    private System.Windows.Forms.TextBox ShipCity;
    private System.Windows.Forms.TextBox ShipName;
    private System.Windows.Forms.TextBox CustomerID;
    private System.Windows.Forms.TextBox OrderID;
    private System.Windows.Forms.Button nextButton;
    private System.Windows.Forms.Button BackButton;
    private System.Windows.Forms.Button showButton;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Data.OleDb.OleDbConnection cn;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.DataGridView dgOrderDetails;
    private System.Windows.Forms.Button showOrderDetailsButton;
    private System.Windows.Forms.TextBox Description;
    private System.Windows.Forms.TextBox CategoryName;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.DataGridView dgCategories;
    private System.Windows.Forms.Button addButton;
    private System.Windows.Forms.Button lastButton;
    private System.Windows.Forms.Button firstButton;
  }
}

