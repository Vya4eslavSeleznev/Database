
namespace Bank
{
  partial class EditCustomer
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
      this.saveChangesButton = new System.Windows.Forms.Button();
      this.birthdayTimePicker = new System.Windows.Forms.DateTimePicker();
      this.passwordTextBox = new System.Windows.Forms.TextBox();
      this.loginTextBox = new System.Windows.Forms.TextBox();
      this.phoneTextBox = new System.Windows.Forms.TextBox();
      this.passportNumTextBox = new System.Windows.Forms.TextBox();
      this.lastNameTextBox = new System.Windows.Forms.TextBox();
      this.firstNameTextBox = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.connection = new System.Data.OleDb.OleDbConnection();
      this.SuspendLayout();
      // 
      // saveChangesButton
      // 
      this.saveChangesButton.Location = new System.Drawing.Point(407, 200);
      this.saveChangesButton.Name = "saveChangesButton";
      this.saveChangesButton.Size = new System.Drawing.Size(419, 28);
      this.saveChangesButton.TabIndex = 80;
      this.saveChangesButton.Text = "Add customer";
      this.saveChangesButton.UseVisualStyleBackColor = true;
      this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
      // 
      // birthdayTimePicker
      // 
      this.birthdayTimePicker.Location = new System.Drawing.Point(163, 173);
      this.birthdayTimePicker.Name = "birthdayTimePicker";
      this.birthdayTimePicker.Size = new System.Drawing.Size(222, 22);
      this.birthdayTimePicker.TabIndex = 79;
      // 
      // passwordTextBox
      // 
      this.passwordTextBox.Location = new System.Drawing.Point(483, 170);
      this.passwordTextBox.Name = "passwordTextBox";
      this.passwordTextBox.Size = new System.Drawing.Size(343, 22);
      this.passwordTextBox.TabIndex = 78;
      this.passwordTextBox.UseSystemPasswordChar = true;
      // 
      // loginTextBox
      // 
      this.loginTextBox.Location = new System.Drawing.Point(484, 138);
      this.loginTextBox.Name = "loginTextBox";
      this.loginTextBox.Size = new System.Drawing.Size(342, 22);
      this.loginTextBox.TabIndex = 77;
      // 
      // phoneTextBox
      // 
      this.phoneTextBox.Location = new System.Drawing.Point(484, 109);
      this.phoneTextBox.Name = "phoneTextBox";
      this.phoneTextBox.Size = new System.Drawing.Size(342, 22);
      this.phoneTextBox.TabIndex = 76;
      // 
      // passportNumTextBox
      // 
      this.passportNumTextBox.Location = new System.Drawing.Point(163, 206);
      this.passportNumTextBox.Name = "passportNumTextBox";
      this.passportNumTextBox.Size = new System.Drawing.Size(222, 22);
      this.passportNumTextBox.TabIndex = 75;
      // 
      // lastNameTextBox
      // 
      this.lastNameTextBox.Location = new System.Drawing.Point(163, 143);
      this.lastNameTextBox.Name = "lastNameTextBox";
      this.lastNameTextBox.Size = new System.Drawing.Size(222, 22);
      this.lastNameTextBox.TabIndex = 74;
      // 
      // firstNameTextBox
      // 
      this.firstNameTextBox.Location = new System.Drawing.Point(163, 112);
      this.firstNameTextBox.Name = "firstNameTextBox";
      this.firstNameTextBox.Size = new System.Drawing.Size(222, 22);
      this.firstNameTextBox.TabIndex = 73;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(404, 175);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(73, 17);
      this.label3.TabIndex = 72;
      this.label3.Text = "Password:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(404, 143);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(47, 17);
      this.label4.TabIndex = 71;
      this.label4.Text = "Login:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(404, 114);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(53, 17);
      this.label5.TabIndex = 70;
      this.label5.Text = "Phone:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(37, 211);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(120, 17);
      this.label8.TabIndex = 69;
      this.label8.Text = "Passport number:";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(37, 178);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(60, 17);
      this.label9.TabIndex = 68;
      this.label9.Text = "Birthday";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(37, 146);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(80, 17);
      this.label10.TabIndex = 67;
      this.label10.Text = "Last Name:";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(37, 117);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(80, 17);
      this.label11.TabIndex = 66;
      this.label11.Text = "First Name:";
      // 
      // connection
      // 
      this.connection.ConnectionString = "Provider=SQLNCLI11;Data Source=LAPTOP-V75FG2GF\\SQLEXPRESS;Integrated Security=SSP" +
    "I;Initial Catalog=Bank";
      // 
      // EditCustomer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(855, 398);
      this.Controls.Add(this.saveChangesButton);
      this.Controls.Add(this.birthdayTimePicker);
      this.Controls.Add(this.passwordTextBox);
      this.Controls.Add(this.loginTextBox);
      this.Controls.Add(this.phoneTextBox);
      this.Controls.Add(this.passportNumTextBox);
      this.Controls.Add(this.lastNameTextBox);
      this.Controls.Add(this.firstNameTextBox);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.label11);
      this.Name = "EditCustomer";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "EditCustomer";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditCustomer_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button saveChangesButton;
    private System.Windows.Forms.DateTimePicker birthdayTimePicker;
    private System.Windows.Forms.TextBox passwordTextBox;
    private System.Windows.Forms.TextBox loginTextBox;
    private System.Windows.Forms.TextBox phoneTextBox;
    private System.Windows.Forms.TextBox passportNumTextBox;
    private System.Windows.Forms.TextBox lastNameTextBox;
    private System.Windows.Forms.TextBox firstNameTextBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;
    private System.Data.OleDb.OleDbConnection connection;
  }
}