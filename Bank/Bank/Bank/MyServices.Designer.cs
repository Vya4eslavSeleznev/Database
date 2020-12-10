
namespace Bank
{
  partial class MyServices
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
      this.myServicesDataGridView = new System.Windows.Forms.DataGridView();
      this.connection = new System.Data.OleDb.OleDbConnection();
      this.dsMyServices = new System.Data.DataSet();
      ((System.ComponentModel.ISupportInitialize)(this.myServicesDataGridView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dsMyServices)).BeginInit();
      this.SuspendLayout();
      // 
      // myServicesDataGridView
      // 
      this.myServicesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.myServicesDataGridView.Location = new System.Drawing.Point(3, 0);
      this.myServicesDataGridView.Name = "myServicesDataGridView";
      this.myServicesDataGridView.RowHeadersWidth = 51;
      this.myServicesDataGridView.RowTemplate.Height = 24;
      this.myServicesDataGridView.Size = new System.Drawing.Size(678, 312);
      this.myServicesDataGridView.TabIndex = 0;
      // 
      // connection
      // 
      this.connection.ConnectionString = "Provider=SQLNCLI11;Data Source=LAPTOP-V75FG2GF\\SQLEXPRESS;Integrated Security=SSP" +
    "I;Initial Catalog=Bank";
      // 
      // dsMyServices
      // 
      this.dsMyServices.DataSetName = "NewDataSet";
      // 
      // MyServices
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(680, 309);
      this.Controls.Add(this.myServicesDataGridView);
      this.Name = "MyServices";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "MyServices";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyServices_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.myServicesDataGridView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dsMyServices)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView myServicesDataGridView;
    private System.Data.OleDb.OleDbConnection connection;
    private System.Data.DataSet dsMyServices;
  }
}