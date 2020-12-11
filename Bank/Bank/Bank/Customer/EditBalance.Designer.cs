
namespace Bank
{
  partial class EditBalance
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
      this.editBalanceButton = new System.Windows.Forms.Button();
      this.cardComboBox = new System.Windows.Forms.ComboBox();
      this.balanceCashTextBox = new System.Windows.Forms.TextBox();
      this.currencyBalanceComboBox = new System.Windows.Forms.ComboBox();
      this.balanceDatePicker = new System.Windows.Forms.DateTimePicker();
      this.balanceNumTextBox = new System.Windows.Forms.TextBox();
      this.label20 = new System.Windows.Forms.Label();
      this.label19 = new System.Windows.Forms.Label();
      this.label18 = new System.Windows.Forms.Label();
      this.label17 = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.connection = new System.Data.OleDb.OleDbConnection();
      this.SuspendLayout();
      // 
      // editBalanceButton
      // 
      this.editBalanceButton.Location = new System.Drawing.Point(87, 170);
      this.editBalanceButton.Name = "editBalanceButton";
      this.editBalanceButton.Size = new System.Drawing.Size(497, 30);
      this.editBalanceButton.TabIndex = 25;
      this.editBalanceButton.Text = "Save changes";
      this.editBalanceButton.UseVisualStyleBackColor = true;
      // 
      // cardComboBox
      // 
      this.cardComboBox.FormattingEnabled = true;
      this.cardComboBox.Location = new System.Drawing.Point(445, 101);
      this.cardComboBox.Name = "cardComboBox";
      this.cardComboBox.Size = new System.Drawing.Size(139, 24);
      this.cardComboBox.TabIndex = 24;
      // 
      // balanceCashTextBox
      // 
      this.balanceCashTextBox.Location = new System.Drawing.Point(445, 69);
      this.balanceCashTextBox.Name = "balanceCashTextBox";
      this.balanceCashTextBox.Size = new System.Drawing.Size(139, 22);
      this.balanceCashTextBox.TabIndex = 23;
      // 
      // currencyBalanceComboBox
      // 
      this.currencyBalanceComboBox.FormattingEnabled = true;
      this.currencyBalanceComboBox.Location = new System.Drawing.Point(205, 143);
      this.currencyBalanceComboBox.Name = "currencyBalanceComboBox";
      this.currencyBalanceComboBox.Size = new System.Drawing.Size(139, 24);
      this.currencyBalanceComboBox.TabIndex = 22;
      // 
      // balanceDatePicker
      // 
      this.balanceDatePicker.Location = new System.Drawing.Point(205, 103);
      this.balanceDatePicker.Name = "balanceDatePicker";
      this.balanceDatePicker.Size = new System.Drawing.Size(139, 22);
      this.balanceDatePicker.TabIndex = 21;
      // 
      // balanceNumTextBox
      // 
      this.balanceNumTextBox.Location = new System.Drawing.Point(205, 67);
      this.balanceNumTextBox.Name = "balanceNumTextBox";
      this.balanceNumTextBox.Size = new System.Drawing.Size(139, 22);
      this.balanceNumTextBox.TabIndex = 20;
      // 
      // label20
      // 
      this.label20.AutoSize = true;
      this.label20.Location = new System.Drawing.Point(362, 108);
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size(42, 17);
      this.label20.TabIndex = 19;
      this.label20.Text = "Card:";
      // 
      // label19
      // 
      this.label19.AutoSize = true;
      this.label19.Location = new System.Drawing.Point(362, 67);
      this.label19.Name = "label19";
      this.label19.Size = new System.Drawing.Size(44, 17);
      this.label19.TabIndex = 18;
      this.label19.Text = "Cash:";
      // 
      // label18
      // 
      this.label18.AutoSize = true;
      this.label18.Location = new System.Drawing.Point(87, 150);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(69, 17);
      this.label18.TabIndex = 17;
      this.label18.Text = "Currency:";
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Location = new System.Drawing.Point(84, 108);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(86, 17);
      this.label17.TabIndex = 16;
      this.label17.Text = "Create date:";
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Location = new System.Drawing.Point(84, 70);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(115, 17);
      this.label16.TabIndex = 15;
      this.label16.Text = "Balance number:";
      // 
      // connection
      // 
      this.connection.ConnectionString = "Provider=SQLNCLI11;Data Source=LAPTOP-V75FG2GF\\SQLEXPRESS;Integrated Security=SSP" +
    "I;Initial Catalog=Bank";
      // 
      // EditBalance
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(680, 309);
      this.Controls.Add(this.editBalanceButton);
      this.Controls.Add(this.cardComboBox);
      this.Controls.Add(this.balanceCashTextBox);
      this.Controls.Add(this.currencyBalanceComboBox);
      this.Controls.Add(this.balanceDatePicker);
      this.Controls.Add(this.balanceNumTextBox);
      this.Controls.Add(this.label20);
      this.Controls.Add(this.label19);
      this.Controls.Add(this.label18);
      this.Controls.Add(this.label17);
      this.Controls.Add(this.label16);
      this.Name = "EditBalance";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "EditBalance";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditBalance_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button editBalanceButton;
    private System.Windows.Forms.ComboBox cardComboBox;
    private System.Windows.Forms.TextBox balanceCashTextBox;
    private System.Windows.Forms.ComboBox currencyBalanceComboBox;
    private System.Windows.Forms.DateTimePicker balanceDatePicker;
    private System.Windows.Forms.TextBox balanceNumTextBox;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.Label label19;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label16;
    private System.Data.OleDb.OleDbConnection connection;
  }
}