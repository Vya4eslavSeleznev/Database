
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
      this.editCardButton = new System.Windows.Forms.Button();
      this.cardNumberTextBox = new System.Windows.Forms.TextBox();
      this.cardServiceComboBox = new System.Windows.Forms.ComboBox();
      this.label22 = new System.Windows.Forms.Label();
      this.label21 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // editCardButton
      // 
      this.editCardButton.Location = new System.Drawing.Point(69, 150);
      this.editCardButton.Name = "editCardButton";
      this.editCardButton.Size = new System.Drawing.Size(524, 30);
      this.editCardButton.TabIndex = 24;
      this.editCardButton.Text = "Save changes";
      this.editCardButton.UseVisualStyleBackColor = true;
      // 
      // cardNumberTextBox
      // 
      this.cardNumberTextBox.Location = new System.Drawing.Point(203, 64);
      this.cardNumberTextBox.Name = "cardNumberTextBox";
      this.cardNumberTextBox.Size = new System.Drawing.Size(390, 22);
      this.cardNumberTextBox.TabIndex = 23;
      // 
      // cardServiceComboBox
      // 
      this.cardServiceComboBox.FormattingEnabled = true;
      this.cardServiceComboBox.Location = new System.Drawing.Point(203, 101);
      this.cardServiceComboBox.Name = "cardServiceComboBox";
      this.cardServiceComboBox.Size = new System.Drawing.Size(390, 24);
      this.cardServiceComboBox.TabIndex = 22;
      // 
      // label22
      // 
      this.label22.AutoSize = true;
      this.label22.Location = new System.Drawing.Point(66, 108);
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size(59, 17);
      this.label22.TabIndex = 21;
      this.label22.Text = "Service:";
      // 
      // label21
      // 
      this.label21.AutoSize = true;
      this.label21.Location = new System.Drawing.Point(66, 69);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(94, 17);
      this.label21.TabIndex = 20;
      this.label21.Text = "Card number:";
      // 
      // EditCard
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(680, 309);
      this.Controls.Add(this.editCardButton);
      this.Controls.Add(this.cardNumberTextBox);
      this.Controls.Add(this.cardServiceComboBox);
      this.Controls.Add(this.label22);
      this.Controls.Add(this.label21);
      this.Name = "EditCard";
      this.Text = "EditCard";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button editCardButton;
    private System.Windows.Forms.TextBox cardNumberTextBox;
    private System.Windows.Forms.ComboBox cardServiceComboBox;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.Label label21;
  }
}