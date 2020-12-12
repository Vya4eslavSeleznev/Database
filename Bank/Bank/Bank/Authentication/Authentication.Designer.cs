
namespace Bank
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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.loginTextBox = new System.Windows.Forms.TextBox();
      this.passwordTextBox = new System.Windows.Forms.TextBox();
      this.logInButton = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.rolesComboBox = new System.Windows.Forms.ComboBox();
      this.connection = new System.Data.OleDb.OleDbConnection();
      this.authenticationDataSet = new System.Data.DataSet();
      ((System.ComponentModel.ISupportInitialize)(this.authenticationDataSet)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(188, 132);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(47, 17);
      this.label1.TabIndex = 1;
      this.label1.Text = "Login:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(188, 172);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(73, 17);
      this.label2.TabIndex = 2;
      this.label2.Text = "Password:";
      // 
      // loginTextBox
      // 
      this.loginTextBox.Location = new System.Drawing.Point(292, 127);
      this.loginTextBox.Name = "loginTextBox";
      this.loginTextBox.Size = new System.Drawing.Size(281, 22);
      this.loginTextBox.TabIndex = 3;
      // 
      // passwordTextBox
      // 
      this.passwordTextBox.Location = new System.Drawing.Point(292, 172);
      this.passwordTextBox.Name = "passwordTextBox";
      this.passwordTextBox.Size = new System.Drawing.Size(281, 22);
      this.passwordTextBox.TabIndex = 4;
      this.passwordTextBox.UseSystemPasswordChar = true;
      // 
      // logInButton
      // 
      this.logInButton.Location = new System.Drawing.Point(191, 308);
      this.logInButton.Name = "logInButton";
      this.logInButton.Size = new System.Drawing.Size(382, 31);
      this.logInButton.TabIndex = 5;
      this.logInButton.Text = "Log in";
      this.logInButton.UseVisualStyleBackColor = true;
      this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(188, 218);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(94, 17);
      this.label3.TabIndex = 6;
      this.label3.Text = "Account type:";
      // 
      // rolesComboBox
      // 
      this.rolesComboBox.FormattingEnabled = true;
      this.rolesComboBox.Location = new System.Drawing.Point(292, 215);
      this.rolesComboBox.Name = "rolesComboBox";
      this.rolesComboBox.Size = new System.Drawing.Size(281, 24);
      this.rolesComboBox.TabIndex = 7;
      // 
      // connection
      // 
      this.connection.ConnectionString = "Provider=SQLNCLI11;Data Source=LAPTOP-V75FG2GF\\SQLEXPRESS;Integrated Security=SSP" +
    "I;Initial Catalog=Bank";
      // 
      // authenticationDataSet
      // 
      this.authenticationDataSet.DataSetName = "NewDataSet";
      // 
      // Authentication
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.rolesComboBox);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.logInButton);
      this.Controls.Add(this.passwordTextBox);
      this.Controls.Add(this.loginTextBox);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "Authentication";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Authentication";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Authentication_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.authenticationDataSet)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox loginTextBox;
    private System.Windows.Forms.TextBox passwordTextBox;
    private System.Windows.Forms.Button logInButton;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox rolesComboBox;
    private System.Data.OleDb.OleDbConnection connection;
    private System.Data.DataSet authenticationDataSet;
  }
}