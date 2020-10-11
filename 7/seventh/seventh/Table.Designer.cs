namespace seventh
{
  partial class Table
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
      this.dgTable = new System.Windows.Forms.DataGridView();
      this.ds = new System.Data.DataSet();
      ((System.ComponentModel.ISupportInitialize)(this.dgTable)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
      this.SuspendLayout();
      // 
      // dgTable
      // 
      this.dgTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgTable.Location = new System.Drawing.Point(0, 0);
      this.dgTable.Name = "dgTable";
      this.dgTable.RowHeadersWidth = 51;
      this.dgTable.RowTemplate.Height = 24;
      this.dgTable.Size = new System.Drawing.Size(800, 450);
      this.dgTable.TabIndex = 0;
      // 
      // ds
      // 
      this.ds.DataSetName = "NewDataSet";
      // 
      // Table
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.dgTable);
      this.Name = "Table";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Table";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Table_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.dgTable)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dgTable;
    private System.Data.DataSet ds;
  }
}