using System;
using System.Data;
using System.Windows.Forms;

namespace seventh
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private void connectToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        cn.Open();
        MessageBox.Show("Conneted!!!!", "Connection", MessageBoxButtons.OK);
      }
      catch (Exception)
      {
        MessageBox.Show("Connection failed!!", "Connection", MessageBoxButtons.OK);
      }

    }

    private void customersToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (Table.customers == false)
      {
        Table Customers = new Table(cn, "Customers");
        Customers.MdiParent = this;
        Customers.Show();
      }
      else
        foreach (Form tbl in this.MdiChildren)
          if (tbl.Text == "Customers")
          {
            tbl.Activate();
            break;
          }

    }

    private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (Table.orders == false)
      {
        Table Orders = new Table(cn, "Orders");
        Orders.MdiParent = this;
        Orders.Show();
      }
      else
        foreach (Form tbl in this.MdiChildren)
          if (tbl.Text == "Orders")
          {
            tbl.Activate();
            break;
          }
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      cn.Close();
    }

    private void addressToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      if (Table.address == false)
      {
        Table Address = new Table(cn, "Address");
        Address.MdiParent = this;
        Address.Show();
      }
      else
        foreach (Form tbl in this.MdiChildren)
          if (tbl.Text == "Address")
          {
            tbl.Activate();
            break;
          }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void cn_StateChange(object sender, StateChangeEventArgs e)
    {
      if (e.CurrentState != ConnectionState.Closed)
      {
        tablesToolStripMenuItem.Enabled = true;
      }
    }

    private void helpToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Seventh lab", " Attention!", MessageBoxButtons.OK);
    }
  }
}
