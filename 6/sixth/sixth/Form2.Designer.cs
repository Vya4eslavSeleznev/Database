namespace sixth
{
  partial class Form2
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
      this.txtGetText = new System.Windows.Forms.TextBox();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.richTextBox2 = new System.Windows.Forms.RichTextBox();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.button2 = new System.Windows.Forms.Button();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtGetText
      // 
      this.txtGetText.Location = new System.Drawing.Point(6, 50);
      this.txtGetText.Name = "txtGetText";
      this.txtGetText.Size = new System.Drawing.Size(206, 22);
      this.txtGetText.TabIndex = 0;
      // 
      // listBox1
      // 
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 16;
      this.listBox1.Items.AddRange(new object[] {
            "Fedorov",
            "Ivanov",
            "Klimchuk",
            "Petrov",
            "Seleznev",
            "Sidorov",
            "Zaharova",
            "Zaitcev"});
      this.listBox1.Location = new System.Drawing.Point(6, 9);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(196, 212);
      this.listBox1.Sorted = true;
      this.listBox1.TabIndex = 1;
      this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(501, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(57, 17);
      this.label1.TabIndex = 2;
      this.label1.Text = "Student";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(501, 42);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(19, 17);
      this.label2.TabIndex = 3;
      this.label2.Text = "Id";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(243, 9);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(202, 22);
      this.textBox1.TabIndex = 4;
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(243, 37);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(202, 22);
      this.textBox2.TabIndex = 5;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(243, 198);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(202, 23);
      this.button1.TabIndex = 6;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // richTextBox1
      // 
      this.richTextBox1.Location = new System.Drawing.Point(243, 103);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new System.Drawing.Size(202, 38);
      this.richTextBox1.TabIndex = 7;
      this.richTextBox1.Text = "";
      // 
      // richTextBox2
      // 
      this.richTextBox2.Location = new System.Drawing.Point(243, 147);
      this.richTextBox2.Name = "richTextBox2";
      this.richTextBox2.Size = new System.Drawing.Size(202, 39);
      this.richTextBox2.TabIndex = 8;
      this.richTextBox2.Text = "";
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage3);
      this.tabControl1.Location = new System.Drawing.Point(-5, 12);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(807, 443);
      this.tabControl1.TabIndex = 9;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.txtGetText);
      this.tabPage1.Location = new System.Drawing.Point(4, 25);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(799, 414);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "tabPage1";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.listBox1);
      this.tabPage2.Controls.Add(this.button1);
      this.tabPage2.Controls.Add(this.richTextBox2);
      this.tabPage2.Controls.Add(this.textBox1);
      this.tabPage2.Controls.Add(this.richTextBox1);
      this.tabPage2.Controls.Add(this.label1);
      this.tabPage2.Controls.Add(this.textBox2);
      this.tabPage2.Controls.Add(this.label2);
      this.tabPage2.Location = new System.Drawing.Point(4, 25);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(799, 414);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "tabPage2";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // tabPage3
      // 
      this.tabPage3.Controls.Add(this.button2);
      this.tabPage3.Controls.Add(this.comboBox1);
      this.tabPage3.Location = new System.Drawing.Point(4, 25);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new System.Drawing.Size(799, 414);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "tabPage3";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // comboBox1
      // 
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(13, 44);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(363, 24);
      this.comboBox1.TabIndex = 0;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(422, 44);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(349, 23);
      this.button2.TabIndex = 1;
      this.button2.Text = "button2";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.tabControl1);
      this.Name = "Form2";
      this.Text = "Form2";
      this.Load += new System.EventHandler(this.Form2_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.tabPage3.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox txtGetText;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.RichTextBox richTextBox2;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.ComboBox comboBox1;
  }
}