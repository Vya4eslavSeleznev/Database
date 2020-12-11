
namespace Bank
{
  partial class AddService
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
      this.addServiceButton = new System.Windows.Forms.Button();
      this.cardServiceComboBox = new System.Windows.Forms.ComboBox();
      this.label22 = new System.Windows.Forms.Label();
      this.connection = new System.Data.OleDb.OleDbConnection();
      this.SuspendLayout();
      // 
      // addServiceButton
      // 
      this.addServiceButton.Location = new System.Drawing.Point(85, 145);
      this.addServiceButton.Name = "addServiceButton";
      this.addServiceButton.Size = new System.Drawing.Size(502, 30);
      this.addServiceButton.TabIndex = 24;
      this.addServiceButton.Text = "Add Service";
      this.addServiceButton.UseVisualStyleBackColor = true;
      this.addServiceButton.Click += new System.EventHandler(this.addServiceButton_Click);
      // 
      // cardServiceComboBox
      // 
      this.cardServiceComboBox.FormattingEnabled = true;
      this.cardServiceComboBox.Location = new System.Drawing.Point(147, 96);
      this.cardServiceComboBox.Name = "cardServiceComboBox";
      this.cardServiceComboBox.Size = new System.Drawing.Size(440, 24);
      this.cardServiceComboBox.TabIndex = 22;
      // 
      // label22
      // 
      this.label22.AutoSize = true;
      this.label22.Location = new System.Drawing.Point(82, 99);
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size(59, 17);
      this.label22.TabIndex = 21;
      this.label22.Text = "Service:";
      // 
      // connection
      // 
      this.connection.ConnectionString = "Provider=SQLNCLI11;Data Source=LAPTOP-V75FG2GF\\SQLEXPRESS;Integrated Security=SSP" +
    "I;Initial Catalog=Bank";
      // 
      // AddService
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(680, 309);
      this.Controls.Add(this.addServiceButton);
      this.Controls.Add(this.cardServiceComboBox);
      this.Controls.Add(this.label22);
      this.Name = "AddService";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "AddService";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddService_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button addServiceButton;
    private System.Windows.Forms.ComboBox cardServiceComboBox;
    private System.Windows.Forms.Label label22;
    private System.Data.OleDb.OleDbConnection connection;
  }
}