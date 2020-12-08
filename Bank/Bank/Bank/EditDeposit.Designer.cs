
namespace Bank
{
  partial class EditDeposit
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
      this.depositInfoTextBox = new System.Windows.Forms.TextBox();
      this.depositPercentTextBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.saveChangesButton = new System.Windows.Forms.Button();
      this.amountDepositTextBox = new System.Windows.Forms.TextBox();
      this.depositTermTextBox = new System.Windows.Forms.TextBox();
      this.currencyDepositComboBox = new System.Windows.Forms.ComboBox();
      this.label25 = new System.Windows.Forms.Label();
      this.label24 = new System.Windows.Forms.Label();
      this.label23 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // depositInfoTextBox
      // 
      this.depositInfoTextBox.Location = new System.Drawing.Point(397, 112);
      this.depositInfoTextBox.Name = "depositInfoTextBox";
      this.depositInfoTextBox.Size = new System.Drawing.Size(175, 22);
      this.depositInfoTextBox.TabIndex = 34;
      // 
      // depositPercentTextBox
      // 
      this.depositPercentTextBox.Location = new System.Drawing.Point(397, 73);
      this.depositPercentTextBox.Name = "depositPercentTextBox";
      this.depositPercentTextBox.Size = new System.Drawing.Size(175, 22);
      this.depositPercentTextBox.TabIndex = 33;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(310, 115);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(83, 17);
      this.label2.TabIndex = 32;
      this.label2.Text = "Description:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(310, 76);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(61, 17);
      this.label1.TabIndex = 31;
      this.label1.Text = "Percent:";
      // 
      // saveChangesButton
      // 
      this.saveChangesButton.Location = new System.Drawing.Point(67, 173);
      this.saveChangesButton.Name = "saveChangesButton";
      this.saveChangesButton.Size = new System.Drawing.Size(510, 26);
      this.saveChangesButton.TabIndex = 30;
      this.saveChangesButton.Text = "Save changes";
      this.saveChangesButton.UseVisualStyleBackColor = true;
      // 
      // amountDepositTextBox
      // 
      this.amountDepositTextBox.Location = new System.Drawing.Point(138, 145);
      this.amountDepositTextBox.Name = "amountDepositTextBox";
      this.amountDepositTextBox.Size = new System.Drawing.Size(166, 22);
      this.amountDepositTextBox.TabIndex = 29;
      // 
      // depositTermTextBox
      // 
      this.depositTermTextBox.Location = new System.Drawing.Point(138, 110);
      this.depositTermTextBox.Name = "depositTermTextBox";
      this.depositTermTextBox.Size = new System.Drawing.Size(166, 22);
      this.depositTermTextBox.TabIndex = 28;
      // 
      // currencyDepositComboBox
      // 
      this.currencyDepositComboBox.FormattingEnabled = true;
      this.currencyDepositComboBox.Location = new System.Drawing.Point(138, 73);
      this.currencyDepositComboBox.Name = "currencyDepositComboBox";
      this.currencyDepositComboBox.Size = new System.Drawing.Size(166, 24);
      this.currencyDepositComboBox.TabIndex = 27;
      // 
      // label25
      // 
      this.label25.AutoSize = true;
      this.label25.Location = new System.Drawing.Point(70, 115);
      this.label25.Name = "label25";
      this.label25.Size = new System.Drawing.Size(45, 17);
      this.label25.TabIndex = 26;
      this.label25.Text = "Term:";
      // 
      // label24
      // 
      this.label24.AutoSize = true;
      this.label24.Location = new System.Drawing.Point(70, 148);
      this.label24.Name = "label24";
      this.label24.Size = new System.Drawing.Size(60, 17);
      this.label24.TabIndex = 25;
      this.label24.Text = "Amount:";
      // 
      // label23
      // 
      this.label23.AutoSize = true;
      this.label23.Location = new System.Drawing.Point(70, 76);
      this.label23.Name = "label23";
      this.label23.Size = new System.Drawing.Size(69, 17);
      this.label23.TabIndex = 24;
      this.label23.Text = "Currency:";
      // 
      // EditDeposit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(680, 309);
      this.Controls.Add(this.depositInfoTextBox);
      this.Controls.Add(this.depositPercentTextBox);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.saveChangesButton);
      this.Controls.Add(this.amountDepositTextBox);
      this.Controls.Add(this.depositTermTextBox);
      this.Controls.Add(this.currencyDepositComboBox);
      this.Controls.Add(this.label25);
      this.Controls.Add(this.label24);
      this.Controls.Add(this.label23);
      this.Name = "EditDeposit";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "EditDeposit";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox depositInfoTextBox;
    private System.Windows.Forms.TextBox depositPercentTextBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button saveChangesButton;
    private System.Windows.Forms.TextBox amountDepositTextBox;
    private System.Windows.Forms.TextBox depositTermTextBox;
    private System.Windows.Forms.ComboBox currencyDepositComboBox;
    private System.Windows.Forms.Label label25;
    private System.Windows.Forms.Label label24;
    private System.Windows.Forms.Label label23;
  }
}