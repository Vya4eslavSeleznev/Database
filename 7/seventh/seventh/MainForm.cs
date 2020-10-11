using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      cn.Close();
    }

    private void customersToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (Table.customers == false)
      {
        Table Customers = new Table(cn, "Customers");
        //Customers.MdiParent = this;
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
        //Orders.MdiParent = this;
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
  }
}
