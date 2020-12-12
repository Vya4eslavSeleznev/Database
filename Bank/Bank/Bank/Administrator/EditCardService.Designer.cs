
namespace Bank
{
  partial class EditCardService
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
      this.editServiceButton = new System.Windows.Forms.Button();
      this.servicePriceNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.label6 = new System.Windows.Forms.Label();
      this.cardServiceTextBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.connection = new System.Data.OleDb.OleDbConnection();
      ((System.ComponentModel.ISupportInitialize)(this.servicePriceNumericUpDown)).BeginInit();
      this.SuspendLayout();
      // 
      // editServiceButton
      // 
      this.editServiceButton.Location = new System.Drawing.Point(76, 138);
      this.editServiceButton.Name = "editServiceButton";
      this.editServiceButton.Size = new System.Drawing.Size(510, 28);
      this.editServiceButton.TabIndex = 57;
      this.editServiceButton.Text = "Save changes";
      this.editServiceButton.UseVisualStyleBackColor = true;
      this.editServiceButton.Click += new System.EventHandler(this.editServiceButton_Click);
      // 
      // servicePriceNumericUpDown
      // 
      this.servicePriceNumericUpDown.Location = new System.Drawing.Point(403, 106);
      this.servicePriceNumericUpDown.Maximum = new decimal(new int[] {
            -402653185,
            -1613725636,
            54210108,
            0});
      this.servicePriceNumericUpDown.Name = "servicePriceNumericUpDown";
      this.servicePriceNumericUpDown.Size = new System.Drawing.Size(183, 22);
      this.servicePriceNumericUpDown.TabIndex = 56;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(336, 109);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(44, 17);
      this.label6.TabIndex = 55;
      this.label6.Text = "Price:";
      // 
      // cardServiceTextBox
      // 
      this.cardServiceTextBox.Location = new System.Drawing.Point(134, 106);
      this.cardServiceTextBox.Name = "cardServiceTextBox";
      this.cardServiceTextBox.Size = new System.Drawing.Size(175, 22);
      this.cardServiceTextBox.TabIndex = 54;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(73, 109);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(49, 17);
      this.label2.TabIndex = 53;
      this.label2.Text = "Name:";
      // 
      // connection
      // 
      this.connection.ConnectionString = "Provider=SQLNCLI11;Data Source=LAPTOP-V75FG2GF\\SQLEXPRESS;Integrated Security=SSP" +
    "I;Initial Catalog=Bank";
      // 
      // EditCardService
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(680, 309);
      this.Controls.Add(this.editServiceButton);
      this.Controls.Add(this.servicePriceNumericUpDown);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.cardServiceTextBox);
      this.Controls.Add(this.label2);
      this.Name = "EditCardService";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "EditCardService";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditCardService_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.servicePriceNumericUpDown)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button editServiceButton;
    private System.Windows.Forms.NumericUpDown servicePriceNumericUpDown;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox cardServiceTextBox;
    private System.Windows.Forms.Label label2;
    private System.Data.OleDb.OleDbConnection connection;
  }
}