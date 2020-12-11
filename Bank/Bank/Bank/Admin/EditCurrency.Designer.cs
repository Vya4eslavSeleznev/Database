
namespace Bank
{
  partial class EditCurrency
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
      this.editCurrencyButton = new System.Windows.Forms.Button();
      this.currencyNameTextBox = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // editCurrencyButton
      // 
      this.editCurrencyButton.Location = new System.Drawing.Point(89, 141);
      this.editCurrencyButton.Name = "editCurrencyButton";
      this.editCurrencyButton.Size = new System.Drawing.Size(501, 28);
      this.editCurrencyButton.TabIndex = 46;
      this.editCurrencyButton.Text = "Save changes";
      this.editCurrencyButton.UseVisualStyleBackColor = true;
      // 
      // currencyNameTextBox
      // 
      this.currencyNameTextBox.Location = new System.Drawing.Point(156, 109);
      this.currencyNameTextBox.Name = "currencyNameTextBox";
      this.currencyNameTextBox.Size = new System.Drawing.Size(434, 22);
      this.currencyNameTextBox.TabIndex = 45;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(88, 112);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(49, 17);
      this.label7.TabIndex = 44;
      this.label7.Text = "Name:";
      // 
      // EditCurrency
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(680, 309);
      this.Controls.Add(this.editCurrencyButton);
      this.Controls.Add(this.currencyNameTextBox);
      this.Controls.Add(this.label7);
      this.Name = "EditCurrency";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "EditCurrency";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button editCurrencyButton;
    private System.Windows.Forms.TextBox currencyNameTextBox;
    private System.Windows.Forms.Label label7;
  }
}