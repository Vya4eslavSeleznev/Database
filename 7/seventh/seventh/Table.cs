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

	  da = new OleDbDataAdapter("SELECT * FROM " + str, cn);
	  DataTable tableCustomers = new DataTable(str);
	  ds.Tables.Add(tableCustomers);
	  dgTable.SetDataBinding(ds, str);
	  da.Fill(ds, str);
	  dgTable.DataMember = str;
	  Text = str;
	  if (Text == "Orders") orders = true;
	  if (Text == "Customers") customers = true;


	}

	private OleDbDataAdapter da;
    public static bool customers, orders;
  }
}
