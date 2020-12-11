
namespace Bank
{
  partial class EditCredit
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
      this.creditInfoTextBox = new System.Windows.Forms.TextBox();
      this.creditPercentTextBox = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.saveChangesButton = new System.Windows.Forms.Button();
      this.creditTermTextBox = new System.Windows.Forms.TextBox();
      this.creditCurrencyComboBox = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // creditInfoTextBox
      // 
      this.creditInfoTextBox.Location = new System.Drawing.Point(406, 117);
      this.creditInfoTextBox.Name = "creditInfoTextBox";
      this.creditInfoTextBox.Size = new System.Drawing.Size(175, 22);
      this.creditInfoTextBox.TabIndex = 45;
      // 
      // creditPercentTextBox
      // 
      this.creditPercentTextBox.Location = new System.Drawing.Point(406, 91);
      this.creditPercentTextBox.Name = "creditPercentTextBox";
      this.creditPercentTextBox.Size = new System.Drawing.Size(175, 22);
      this.creditPercentTextBox.TabIndex = 44;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(319, 120);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(83, 17);
      this.label3.TabIndex = 43;
      this.label3.Text = "Description:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(319, 94);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(61, 17);
      this.label4.TabIndex = 42;
      this.label4.Text = "Percent:";
      // 
      // saveChangesButton
      // 
      this.saveChangesButton.Location = new System.Drawing.Point(76, 150);
      this.saveChangesButton.Name = "saveChangesButton";
      this.saveChangesButton.Size = new System.Drawing.Size(510, 27);
      this.saveChangesButton.TabIndex = 41;
      this.saveChangesButton.Text = "Save changes";
      this.saveChangesButton.UseVisualStyleBackColor = true;
      // 
      // creditTermTextBox
      // 
      this.creditTermTextBox.Location = new System.Drawing.Point(147, 117);
      this.creditTermTextBox.Name = "creditTermTextBox";
      this.creditTermTextBox.Size = new System.Drawing.Size(166, 22);
      this.creditTermTextBox.TabIndex = 40;
      // 
      // creditCurrencyComboBox
      // 
      this.creditCurrencyComboBox.FormattingEnabled = true;
      this.creditCurrencyComboBox.Location = new System.Drawing.Point(147, 91);
      this.creditCurrencyComboBox.Name = "creditCurrencyComboBox";
      this.creditCurrencyComboBox.Size = new System.Drawing.Size(166, 24);
      this.creditCurrencyComboBox.TabIndex = 39;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(79, 120);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(45, 17);
      this.label5.TabIndex = 38;
      this.label5.Text = "Term:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(79, 94);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(69, 17);
      this.label7.TabIndex = 37;
      this.label7.Text = "Currency:";
      // 
      // EditCredit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(680, 309);
      this.Controls.Add(this.creditInfoTextBox);
      this.Controls.Add(this.creditPercentTextBox);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.saveChangesButton);
      this.Controls.Add(this.creditTermTextBox);
      this.Controls.Add(this.creditCurrencyComboBox);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label7);
      this.Name = "EditCredit";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "EditCredit";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox creditInfoTextBox;
    private System.Windows.Forms.TextBox creditPercentTextBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button saveChangesButton;
    private System.Windows.Forms.TextBox creditTermTextBox;
    private System.Windows.Forms.ComboBox creditCurrencyComboBox;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label7;
  }
}