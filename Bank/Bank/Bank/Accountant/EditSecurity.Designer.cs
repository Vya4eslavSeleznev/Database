
namespace Bank
{
  partial class EditSecurity
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
      this.percentTextBox = new System.Windows.Forms.TextBox();
      this.securityPriceTextBox = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.saveChangesButton = new System.Windows.Forms.Button();
      this.securityNameTextBox = new System.Windows.Forms.TextBox();
      this.securityCurrencyComboBox = new System.Windows.Forms.ComboBox();
      this.label10 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.connection = new System.Data.OleDb.OleDbConnection();
      this.SuspendLayout();
      // 
      // percentTextBox
      // 
      this.percentTextBox.Location = new System.Drawing.Point(396, 117);
      this.percentTextBox.Name = "percentTextBox";
      this.percentTextBox.Size = new System.Drawing.Size(175, 22);
      this.percentTextBox.TabIndex = 45;
      // 
      // securityPriceTextBox
      // 
      this.securityPriceTextBox.Location = new System.Drawing.Point(396, 89);
      this.securityPriceTextBox.Name = "securityPriceTextBox";
      this.securityPriceTextBox.Size = new System.Drawing.Size(175, 22);
      this.securityPriceTextBox.TabIndex = 44;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(309, 120);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(61, 17);
      this.label8.TabIndex = 43;
      this.label8.Text = "Percent:";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(309, 92);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(44, 17);
      this.label9.TabIndex = 42;
      this.label9.Text = "Price:";
      // 
      // saveChangesButton
      // 
      this.saveChangesButton.Location = new System.Drawing.Point(66, 145);
      this.saveChangesButton.Name = "saveChangesButton";
      this.saveChangesButton.Size = new System.Drawing.Size(510, 31);
      this.saveChangesButton.TabIndex = 41;
      this.saveChangesButton.Text = "Save changes";
      this.saveChangesButton.UseVisualStyleBackColor = true;
      this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
      // 
      // securityNameTextBox
      // 
      this.securityNameTextBox.Location = new System.Drawing.Point(137, 115);
      this.securityNameTextBox.Name = "securityNameTextBox";
      this.securityNameTextBox.Size = new System.Drawing.Size(166, 22);
      this.securityNameTextBox.TabIndex = 40;
      // 
      // securityCurrencyComboBox
      // 
      this.securityCurrencyComboBox.FormattingEnabled = true;
      this.securityCurrencyComboBox.Location = new System.Drawing.Point(137, 89);
      this.securityCurrencyComboBox.Name = "securityCurrencyComboBox";
      this.securityCurrencyComboBox.Size = new System.Drawing.Size(166, 24);
      this.securityCurrencyComboBox.TabIndex = 39;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(69, 120);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(49, 17);
      this.label10.TabIndex = 38;
      this.label10.Text = "Name:";
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(69, 92);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(69, 17);
      this.label12.TabIndex = 37;
      this.label12.Text = "Currency:";
      // 
      // connection
      // 
      this.connection.ConnectionString = "Provider=SQLNCLI11;Data Source=LAPTOP-V75FG2GF\\SQLEXPRESS;Integrated Security=SSP" +
    "I;Initial Catalog=Bank";
      // 
      // EditSecurity
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(680, 309);
      this.Controls.Add(this.percentTextBox);
      this.Controls.Add(this.securityPriceTextBox);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.saveChangesButton);
      this.Controls.Add(this.securityNameTextBox);
      this.Controls.Add(this.securityCurrencyComboBox);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.label12);
      this.Name = "EditSecurity";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "EditSecurity";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditSecurity_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox percentTextBox;
    private System.Windows.Forms.TextBox securityPriceTextBox;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Button saveChangesButton;
    private System.Windows.Forms.TextBox securityNameTextBox;
    private System.Windows.Forms.ComboBox securityCurrencyComboBox;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label12;
    private System.Data.OleDb.OleDbConnection connection;
  }
}