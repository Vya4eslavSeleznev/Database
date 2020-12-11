
namespace Bank
{
  partial class EditService
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
      this.cardComboBox = new System.Windows.Forms.ComboBox();
      this.editServiceButton = new System.Windows.Forms.Button();
      this.cardServiceComboBox = new System.Windows.Forms.ComboBox();
      this.label22 = new System.Windows.Forms.Label();
      this.label21 = new System.Windows.Forms.Label();
      this.connection = new System.Data.OleDb.OleDbConnection();
      this.SuspendLayout();
      // 
      // cardComboBox
      // 
      this.cardComboBox.FormattingEnabled = true;
      this.cardComboBox.Location = new System.Drawing.Point(117, 96);
      this.cardComboBox.Name = "cardComboBox";
      this.cardComboBox.Size = new System.Drawing.Size(196, 24);
      this.cardComboBox.TabIndex = 30;
      // 
      // editServiceButton
      // 
      this.editServiceButton.Location = new System.Drawing.Point(78, 142);
      this.editServiceButton.Name = "editServiceButton";
      this.editServiceButton.Size = new System.Drawing.Size(502, 30);
      this.editServiceButton.TabIndex = 29;
      this.editServiceButton.Text = "Save changes";
      this.editServiceButton.UseVisualStyleBackColor = true;
      // 
      // cardServiceComboBox
      // 
      this.cardServiceComboBox.FormattingEnabled = true;
      this.cardServiceComboBox.Location = new System.Drawing.Point(384, 96);
      this.cardServiceComboBox.Name = "cardServiceComboBox";
      this.cardServiceComboBox.Size = new System.Drawing.Size(196, 24);
      this.cardServiceComboBox.TabIndex = 28;
      // 
      // label22
      // 
      this.label22.AutoSize = true;
      this.label22.Location = new System.Drawing.Point(319, 100);
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size(59, 17);
      this.label22.TabIndex = 27;
      this.label22.Text = "Service:";
      // 
      // label21
      // 
      this.label21.AutoSize = true;
      this.label21.Location = new System.Drawing.Point(75, 100);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(42, 17);
      this.label21.TabIndex = 26;
      this.label21.Text = "Card:";
      // 
      // connection
      // 
      this.connection.ConnectionString = "Provider=SQLNCLI11;Data Source=LAPTOP-V75FG2GF\\SQLEXPRESS;Integrated Security=SSP" +
    "I;Initial Catalog=Bank";
      // 
      // EditService
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(680, 309);
      this.Controls.Add(this.cardComboBox);
      this.Controls.Add(this.editServiceButton);
      this.Controls.Add(this.cardServiceComboBox);
      this.Controls.Add(this.label22);
      this.Controls.Add(this.label21);
      this.Name = "EditService";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "EditService";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditService_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox cardComboBox;
    private System.Windows.Forms.Button editServiceButton;
    private System.Windows.Forms.ComboBox cardServiceComboBox;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.Label label21;
    private System.Data.OleDb.OleDbConnection connection;
  }
}