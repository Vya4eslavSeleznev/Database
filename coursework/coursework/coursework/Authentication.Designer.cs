
namespace coursework
{
  partial class Authentication
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authentication));
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.loginTextBox = new System.Windows.Forms.TextBox();
      this.passwordTextBox = new System.Windows.Forms.TextBox();
      this.authenticationPictureBox = new System.Windows.Forms.PictureBox();
      this.logInButton = new System.Windows.Forms.Button();
      this.registrationButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.authenticationPictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(269, 227);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "Login:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(245, 275);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(73, 20);
      this.label2.TabIndex = 1;
      this.label2.Text = "Password:";
      // 
      // loginTextBox
      // 
      this.loginTextBox.Location = new System.Drawing.Point(349, 220);
      this.loginTextBox.Name = "loginTextBox";
      this.loginTextBox.Size = new System.Drawing.Size(191, 27);
      this.loginTextBox.TabIndex = 2;
      // 
      // passwordTextBox
      // 
      this.passwordTextBox.Location = new System.Drawing.Point(349, 268);
      this.passwordTextBox.Name = "passwordTextBox";
      this.passwordTextBox.Size = new System.Drawing.Size(191, 27);
      this.passwordTextBox.TabIndex = 3;
      this.passwordTextBox.UseSystemPasswordChar = true;
      // 
      // authenticationPictureBox
      // 
      this.authenticationPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("authenticationPictureBox.Image")));
      this.authenticationPictureBox.Location = new System.Drawing.Point(43, 30);
      this.authenticationPictureBox.Name = "authenticationPictureBox";
      this.authenticationPictureBox.Size = new System.Drawing.Size(720, 138);
      this.authenticationPictureBox.TabIndex = 4;
      this.authenticationPictureBox.TabStop = false;
      // 
      // logInButton
      // 
      this.logInButton.Location = new System.Drawing.Point(411, 353);
      this.logInButton.Name = "logInButton";
      this.logInButton.Size = new System.Drawing.Size(129, 31);
      this.logInButton.TabIndex = 5;
      this.logInButton.Text = "Log in";
      this.logInButton.UseVisualStyleBackColor = true;
      // 
      // registrationButton
      // 
      this.registrationButton.Location = new System.Drawing.Point(245, 353);
      this.registrationButton.Name = "registrationButton";
      this.registrationButton.Size = new System.Drawing.Size(134, 31);
      this.registrationButton.TabIndex = 6;
      this.registrationButton.Text = "Registration";
      this.registrationButton.UseVisualStyleBackColor = true;
      // 
      // Authentication
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.registrationButton);
      this.Controls.Add(this.logInButton);
      this.Controls.Add(this.authenticationPictureBox);
      this.Controls.Add(this.passwordTextBox);
      this.Controls.Add(this.loginTextBox);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "Authentication";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Authentication";
      ((System.ComponentModel.ISupportInitialize)(this.authenticationPictureBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox loginTextBox;
    private System.Windows.Forms.TextBox passwordTextBox;
    private System.Windows.Forms.PictureBox authenticationPictureBox;
    private System.Windows.Forms.Button logInButton;
    private System.Windows.Forms.Button registrationButton;
  }
}