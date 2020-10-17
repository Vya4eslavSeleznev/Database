namespace seventh
{
  partial class MainForm
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
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.customersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.addressToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
      this.addressToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.wwToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.cn = new System.Data.OleDb.OleDbConnection();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tablesToolStripMenuItem,
            this.wwToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.MdiWindowListItem = this.windowToolStripMenuItem;
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(800, 28);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // tablesToolStripMenuItem
      // 
      this.tablesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customersToolStripMenuItem,
            this.toolStripMenuItem2,
            this.ordersToolStripMenuItem,
            this.addressToolStripMenuItem,
            this.addressToolStripMenuItem1});
      this.tablesToolStripMenuItem.Enabled = false;
      this.tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
      this.tablesToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
      this.tablesToolStripMenuItem.Text = "Tables";
      // 
      // customersToolStripMenuItem
      // 
      this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
      this.customersToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
      this.customersToolStripMenuItem.Text = "Customers";
      this.customersToolStripMenuItem.Click += new System.EventHandler(this.customersToolStripMenuItem_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(221, 6);
      // 
      // ordersToolStripMenuItem
      // 
      this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
      this.ordersToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
      this.ordersToolStripMenuItem.Text = "Orders";
      this.ordersToolStripMenuItem.Click += new System.EventHandler(this.ordersToolStripMenuItem_Click);
      // 
      // addressToolStripMenuItem
      // 
      this.addressToolStripMenuItem.Name = "addressToolStripMenuItem";
      this.addressToolStripMenuItem.Size = new System.Drawing.Size(221, 6);
      // 
      // addressToolStripMenuItem1
      // 
      this.addressToolStripMenuItem1.Name = "addressToolStripMenuItem1";
      this.addressToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
      this.addressToolStripMenuItem1.Text = "Address";
      this.addressToolStripMenuItem1.Click += new System.EventHandler(this.addressToolStripMenuItem1_Click);
      // 
      // wwToolStripMenuItem
      // 
      this.wwToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
      this.wwToolStripMenuItem.Name = "wwToolStripMenuItem";
      this.wwToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
      this.wwToolStripMenuItem.Text = "File";
      // 
      // connectToolStripMenuItem
      // 
      this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
      this.connectToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
      this.connectToolStripMenuItem.Text = "Connect";
      this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // windowToolStripMenuItem
      // 
      this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
      this.windowToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
      this.windowToolStripMenuItem.Text = "Window";
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
      this.helpToolStripMenuItem.Text = "Help";
      this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
      // 
      // cn
      // 
      this.cn.ConnectionString = "Provider=SQLNCLI11;Data Source=LAPTOP-V75FG2GF\\SQLEXPRESS;Integrated Security=SSP" +
    "I;Initial Catalog=Company";
      this.cn.StateChange += new System.Data.StateChangeEventHandler(this.cn_StateChange);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.menuStrip1);
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainForm";
      this.Text = "MainForm";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem wwToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem tablesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem customersToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
    private System.Data.OleDb.OleDbConnection cn;
    private System.Windows.Forms.ToolStripSeparator addressToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem addressToolStripMenuItem1;
  }
}

