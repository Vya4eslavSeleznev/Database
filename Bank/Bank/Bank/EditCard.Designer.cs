
namespace Bank
{
  partial class EditCard
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
      this.connection = new System.Data.OleDb.OleDbConnection();
      this.cardBalanceIdComboBox = new System.Windows.Forms.ComboBox();
      this.label20 = new System.Windows.Forms.Label();
      this.editCardButton = new System.Windows.Forms.Button();
      this.cardNumberTextBox = new System.Windows.Forms.TextBox();
      this.label21 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // connection
      // 
      this.connection.ConnectionString = "Provider=SQLNCLI11;Data Source=LAPTOP-V75FG2GF\\SQLEXPRESS;Integrated Security=SSP" +
    "I;Initial Catalog=Bank";
      // 
      // cardBalanceIdComboBox
      // 
      this.cardBalanceIdComboBox.FormattingEnabled = true;
      this.cardBalanceIdComboBox.Location = new System.Drawing.Point(403, 122);
      this.cardBalanceIdComboBox.Name = "cardBalanceIdComboBox";
      this.cardBalanceIdComboBox.Size = new System.Drawing.Size(196, 24);
      this.cardBalanceIdComboBox.TabIndex = 28;
      // 
      // label20
      // 
      this.label20.AutoSize = true;
      this.label20.Location = new System.Drawing.Point(334, 127);
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size(63, 17);
      this.label20.TabIndex = 27;
      this.label20.Text = "Balance:";
      // 
      // editCardButton
      // 
      this.editCardButton.Location = new System.Drawing.Point(78, 157);
      this.editCardButton.Name = "editCardButton";
      this.editCardButton.Size = new System.Drawing.Size(524, 30);
      this.editCardButton.TabIndex = 26;
      this.editCardButton.Text = "Edit Card";
      this.editCardButton.UseVisualStyleBackColor = true;
      this.editCardButton.Click += new System.EventHandler(this.editCardButton_Click_1);
      // 
      // cardNumberTextBox
      // 
      this.cardNumberTextBox.Location = new System.Drawing.Point(181, 124);
      this.cardNumberTextBox.Name = "cardNumberTextBox";
      this.cardNumberTextBox.Size = new System.Drawing.Size(147, 22);
      this.cardNumberTextBox.TabIndex = 25;
      // 
      // label21
      // 
      this.label21.AutoSize = true;
      this.label21.Location = new System.Drawing.Point(81, 129);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(94, 17);
      this.label21.TabIndex = 24;
      this.label21.Text = "Card number:";
      // 
      // EditCard
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(680, 309);
      this.Controls.Add(this.cardBalanceIdComboBox);
      this.Controls.Add(this.label20);
      this.Controls.Add(this.editCardButton);
      this.Controls.Add(this.cardNumberTextBox);
      this.Controls.Add(this.label21);
      this.Name = "EditCard";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "EditCard";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditCard_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Data.OleDb.OleDbConnection connection;
    private System.Windows.Forms.ComboBox cardBalanceIdComboBox;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.Button editCardButton;
    private System.Windows.Forms.TextBox cardNumberTextBox;
    private System.Windows.Forms.Label label21;
  }
}