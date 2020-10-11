using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace seventh
{
  public partial class Table : Form
  {
    public Table(OleDbConnection db, String str)
    {
      InitializeComponent();

	  da = new OleDbDataAdapter("SELECT * FROM " + str, db);
	  DataTable tableCustomers = new DataTable(str);
	  ds.Tables.Add(tableCustomers);

	  dgTable.AutoGenerateColumns = true;
	  dgTable.DataSource = ds;
	  dgTable.DataMember = str;

	  da.Fill(ds, str);
	  dgTable.DataMember = str;
	  Text = str;

	  if (Text == "Orders")
		orders = true;

	  if (Text == "Customers")
		customers = true;

	  if (Text == "Address")
		address = true;
	}

	private OleDbDataAdapter da;
    public static bool customers, orders, address;

    private void Table_FormClosing(object sender, FormClosingEventArgs e)
    {
	  if (Text == "Orders")
		orders = false;

	  if (Text == "Customers")
		customers = false;

	  if (Text == "Address")
		address = false;
	}
  }
}
