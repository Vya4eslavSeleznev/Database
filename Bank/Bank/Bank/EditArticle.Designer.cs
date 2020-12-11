
namespace Bank
{
  partial class EditArticle
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
      this.editArticleButton = new System.Windows.Forms.Button();
      this.nameArticleTextBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // editArticleButton
      // 
      this.editArticleButton.Location = new System.Drawing.Point(126, 152);
      this.editArticleButton.Name = "editArticleButton";
      this.editArticleButton.Size = new System.Drawing.Size(422, 31);
      this.editArticleButton.TabIndex = 6;
      this.editArticleButton.Text = "Save changes";
      this.editArticleButton.UseVisualStyleBackColor = true;
      // 
      // nameArticleTextBox
      // 
      this.nameArticleTextBox.Location = new System.Drawing.Point(178, 114);
      this.nameArticleTextBox.Name = "nameArticleTextBox";
      this.nameArticleTextBox.Size = new System.Drawing.Size(370, 22);
      this.nameArticleTextBox.TabIndex = 5;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(123, 117);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 17);
      this.label1.TabIndex = 4;
      this.label1.Text = "Name:";
      // 
      // EditArticle
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(680, 309);
      this.Controls.Add(this.editArticleButton);
      this.Controls.Add(this.nameArticleTextBox);
      this.Controls.Add(this.label1);
      this.Name = "EditArticle";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "EditArticle";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button editArticleButton;
    private System.Windows.Forms.TextBox nameArticleTextBox;
    private System.Windows.Forms.Label label1;
  }
}