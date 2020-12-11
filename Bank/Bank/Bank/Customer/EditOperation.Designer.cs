
namespace Bank
{
  partial class EditOperation
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
      this.dateOfOperationPicker = new System.Windows.Forms.DateTimePicker();
      this.whoseBalanceTextBox = new System.Windows.Forms.TextBox();
      this.operationCashTextBox = new System.Windows.Forms.TextBox();
      this.balanceIdComboBox = new System.Windows.Forms.ComboBox();
      this.currencyOperationComboBox = new System.Windows.Forms.ComboBox();
      this.articleComboBox = new System.Windows.Forms.ComboBox();
      this.editOperationButton = new System.Windows.Forms.Button();
      this.label14 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.connection = new System.Data.OleDb.OleDbConnection();
      this.SuspendLayout();
      // 
      // dateOfOperationPicker
      // 
      this.dateOfOperationPicker.Location = new System.Drawing.Point(406, 111);
      this.dateOfOperationPicker.Name = "dateOfOperationPicker";
      this.dateOfOperationPicker.Size = new System.Drawing.Size(189, 22);
      this.dateOfOperationPicker.TabIndex = 34;
      // 
      // whoseBalanceTextBox
      // 
      this.whoseBalanceTextBox.Location = new System.Drawing.Point(467, 139);
      this.whoseBalanceTextBox.Name = "whoseBalanceTextBox";
      this.whoseBalanceTextBox.Size = new System.Drawing.Size(128, 22);
      this.whoseBalanceTextBox.TabIndex = 33;
      // 
      // operationCashTextBox
      // 
      this.operationCashTextBox.Location = new System.Drawing.Point(405, 83);
      this.operationCashTextBox.Name = "operationCashTextBox";
      this.operationCashTextBox.Size = new System.Drawing.Size(190, 22);
      this.operationCashTextBox.TabIndex = 32;
      // 
      // balanceIdComboBox
      // 
      this.balanceIdComboBox.FormattingEnabled = true;
      this.balanceIdComboBox.Location = new System.Drawing.Point(164, 139);
      this.balanceIdComboBox.Name = "balanceIdComboBox";
      this.balanceIdComboBox.Size = new System.Drawing.Size(157, 24);
      this.balanceIdComboBox.TabIndex = 31;
      // 
      // currencyOperationComboBox
      // 
      this.currencyOperationComboBox.FormattingEnabled = true;
      this.currencyOperationComboBox.Location = new System.Drawing.Point(164, 109);
      this.currencyOperationComboBox.Name = "currencyOperationComboBox";
      this.currencyOperationComboBox.Size = new System.Drawing.Size(157, 24);
      this.currencyOperationComboBox.TabIndex = 30;
      // 
      // articleComboBox
      // 
      this.articleComboBox.FormattingEnabled = true;
      this.articleComboBox.Location = new System.Drawing.Point(164, 79);
      this.articleComboBox.Name = "articleComboBox";
      this.articleComboBox.Size = new System.Drawing.Size(157, 24);
      this.articleComboBox.TabIndex = 29;
      // 
      // editOperationButton
      // 
      this.editOperationButton.Location = new System.Drawing.Point(93, 166);
      this.editOperationButton.Name = "editOperationButton";
      this.editOperationButton.Size = new System.Drawing.Size(502, 26);
      this.editOperationButton.TabIndex = 28;
      this.editOperationButton.Text = "Save changes";
      this.editOperationButton.UseVisualStyleBackColor = true;
      this.editOperationButton.Click += new System.EventHandler(this.editOperationButton_Click);
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(358, 142);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(110, 17);
      this.label14.TabIndex = 27;
      this.label14.Text = "Whose balance:";
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(358, 114);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(42, 17);
      this.label13.TabIndex = 26;
      this.label13.Text = "Date:";
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(358, 86);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(44, 17);
      this.label12.TabIndex = 25;
      this.label12.Text = "Cash:";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(93, 142);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(63, 17);
      this.label11.TabIndex = 24;
      this.label11.Text = "Balance:";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(93, 114);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(69, 17);
      this.label10.TabIndex = 23;
      this.label10.Text = "Currency:";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(93, 86);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(51, 17);
      this.label9.TabIndex = 22;
      this.label9.Text = "Article:";
      // 
      // connection
      // 
      this.connection.ConnectionString = "Provider=SQLNCLI11;Data Source=LAPTOP-V75FG2GF\\SQLEXPRESS;Integrated Security=SSP" +
    "I;Initial Catalog=Bank";
      // 
      // EditOperation
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(680, 309);
      this.Controls.Add(this.dateOfOperationPicker);
      this.Controls.Add(this.whoseBalanceTextBox);
      this.Controls.Add(this.operationCashTextBox);
      this.Controls.Add(this.balanceIdComboBox);
      this.Controls.Add(this.currencyOperationComboBox);
      this.Controls.Add(this.articleComboBox);
      this.Controls.Add(this.editOperationButton);
      this.Controls.Add(this.label14);
      this.Controls.Add(this.label13);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.label9);
      this.Name = "EditOperation";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "EditOperation";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditOperation_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DateTimePicker dateOfOperationPicker;
    private System.Windows.Forms.TextBox whoseBalanceTextBox;
    private System.Windows.Forms.TextBox operationCashTextBox;
    private System.Windows.Forms.ComboBox balanceIdComboBox;
    private System.Windows.Forms.ComboBox currencyOperationComboBox;
    private System.Windows.Forms.ComboBox articleComboBox;
    private System.Windows.Forms.Button editOperationButton;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label9;
    private System.Data.OleDb.OleDbConnection connection;
  }
}