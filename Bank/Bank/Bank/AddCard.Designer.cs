
namespace Bank
{
  partial class AddCard
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
      this.addCardButton = new System.Windows.Forms.Button();
      this.balanceComboBox = new System.Windows.Forms.ComboBox();
      this.label22 = new System.Windows.Forms.Label();
      this.label21 = new System.Windows.Forms.Label();
      this.cardComboBox = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // addCardButton
      // 
      this.addCardButton.Location = new System.Drawing.Point(70, 143);
      this.addCardButton.Name = "addCardButton";
      this.addCardButton.Size = new System.Drawing.Size(524, 30);
      this.addCardButton.TabIndex = 24;
      this.addCardButton.Text = "Add Card";
      this.addCardButton.UseVisualStyleBackColor = true;
      // 
      // balanceComboBox
      // 
      this.balanceComboBox.FormattingEnabled = true;
      this.balanceComboBox.Location = new System.Drawing.Point(398, 94);
      this.balanceComboBox.Name = "balanceComboBox";
      this.balanceComboBox.Size = new System.Drawing.Size(180, 24);
      this.balanceComboBox.TabIndex = 22;
      // 
      // label22
      // 
      this.label22.AutoSize = true;
      this.label22.Location = new System.Drawing.Point(333, 101);
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size(63, 17);
      this.label22.TabIndex = 21;
      this.label22.Text = "Balance:";
      // 
      // label21
      // 
      this.label21.AutoSize = true;
      this.label21.Location = new System.Drawing.Point(73, 101);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(42, 17);
      this.label21.TabIndex = 20;
      this.label21.Text = "Card:";
      // 
      // cardComboBox
      // 
      this.cardComboBox.FormattingEnabled = true;
      this.cardComboBox.Location = new System.Drawing.Point(121, 94);
      this.cardComboBox.Name = "cardComboBox";
      this.cardComboBox.Size = new System.Drawing.Size(212, 24);
      this.cardComboBox.TabIndex = 25;
      // 
      // AddCard
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(680, 309);
      this.Controls.Add(this.cardComboBox);
      this.Controls.Add(this.addCardButton);
      this.Controls.Add(this.balanceComboBox);
      this.Controls.Add(this.label22);
      this.Controls.Add(this.label21);
      this.Name = "AddCard";
      this.Text = "AddCard";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button addCardButton;
    private System.Windows.Forms.ComboBox balanceComboBox;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.Label label21;
    private System.Windows.Forms.ComboBox cardComboBox;
  }
}