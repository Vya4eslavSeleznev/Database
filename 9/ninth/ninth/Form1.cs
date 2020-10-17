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


namespace ninth
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      cn.Open();

	  OleDbCommand IDS = new OleDbCommand("SELECT CustomerID FROM Customers", cn);
	  OleDbDataReader rdr = IDS.ExecuteReader();

	  while (rdr.Read())
		cbCID.Items.Add(rdr["CustomerID"]);

	  rdr.Close();

	  IDS.CommandText = "SELECT EmployeeID, LastName FROM Employees";
	  rdr = IDS.ExecuteReader();

	  while (rdr.Read())
		cbEID.Items.Add(rdr["EmployeeID"] + " - " + rdr["LastName"]);

	  rdr.Close();

	  IDS.CommandText = "SELECT ShipperID, CompanyName FROM Shippers";
	  rdr = IDS.ExecuteReader();

	  while (rdr.Read())
		cbSV.Items.Add(rdr["ShipperID"] + " - " + rdr["CompanyName"]);

	  rdr.Close();
	}

	private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      cn.Close();
    }

    private void Insert_Click(object sender, EventArgs e)
    {
	  String strSQL = "INSERT INTO Customers (CompanyName, " +
	  "ContactName, Phone, Country, City) VALUES (?, ?, ?, ?, ?)";

	  OleDbCommand cmdIC = new OleDbCommand(strSQL, cn);

	  cmdIC.Parameters.Add("@p1", OleDbType.VarChar, 40);
	  cmdIC.Parameters.Add("@p2", OleDbType.VarChar, 40);
	  cmdIC.Parameters.Add("@p3", OleDbType.VarChar, 40);
	  cmdIC.Parameters.Add("@p4", OleDbType.VarChar, 40);
	  cmdIC.Parameters.Add("@p5", OleDbType.VarChar, 40);

	  if(CompanyName.Text == "" || ContactName.Text == "" ||
		 Phone.Text == "" || Country.Text == "" ||
		 City.Text == "")
      {
		MessageBox.Show("Null value in text box");
		return;
      }

	  cmdIC.Parameters[0].Value = CompanyName.Text;
	  cmdIC.Parameters[1].Value = ContactName.Text;
	  cmdIC.Parameters[2].Value = Phone.Text;
	  cmdIC.Parameters[3].Value = Country.Text;
	  cmdIC.Parameters[4].Value = City.Text;

	  try
	  {
		cmdIC.ExecuteNonQuery();
		MessageBox.Show("Record successfully inserted!");

		CompanyName.Text = "";
		ContactName.Text = "";
		Phone.Text = "";
		Country.Text = "";
		City.Text = "";
	  }
	  catch (OleDbException exc)
	  {
		MessageBox.Show(exc.ToString());
	  }
	}

    private void addButton_Click(object sender, EventArgs e)
    {
	  String strSQL = "INSERT INTO Orders (CustomerID, EmployeeID, " +
	  "ShipVia, OrderDate) VALUES (?, ?, ?, ?)";
	  OleDbCommand cmdIC = new OleDbCommand(strSQL, cn);

	  cmdIC.Parameters.Add("@CID", OleDbType.Integer);
	  cmdIC.Parameters.Add("@EID", OleDbType.Integer);
	  cmdIC.Parameters.Add("@SV", OleDbType.Integer);
	  cmdIC.Parameters.Add("@OD", OleDbType.Date);

	  cmdIC.Parameters[0].Value = cbCID.SelectedItem.ToString();

	  String s = cbEID.SelectedItem.ToString();
	  cmdIC.Parameters[1].Value = s.Remove(s.IndexOf("-") - 1, s.Length - s.IndexOf("-") + 1);

	  s = cbSV.SelectedItem.ToString();
	  cmdIC.Parameters[2].Value = s.Remove(s.IndexOf("-") - 1, s.Length - s.IndexOf("-") + 1);
	  cmdIC.Parameters[3].Value = OrderDate.Text;

	  try
	  {
		int iRowAff = cmdIC.ExecuteNonQuery();
		MessageBox.Show("Orders: rows affected - " + iRowAff.ToString());

		cbCID.SelectedText = "";
		cbEID.SelectedText = "";
		cbSV.SelectedText = "";
		OrderDate.Text = "";

		cmdIC.Dispose();
		iRowAff = 0;

		strSQL = "DECLARE @OID int SELECT @OID = max(OrderID) FROM Orders INSERT INTO [Order Details] (OrderID, ProductID, UnitPrice, Quantity, Discount) VALUES (@OID, ?, ?, ?, ?)";

		cmdIC = new OleDbCommand(strSQL, cn);

		cmdIC.Parameters.Add("@PID", OleDbType.Integer);
		cmdIC.Parameters.Add("@UP", OleDbType.Decimal);
		cmdIC.Parameters.Add("@QTY", OleDbType.Integer);
		cmdIC.Parameters.Add("@DST", OleDbType.Decimal);

		int iRowID = 0;

		for (iRowID = 0; iRowID < dsOD.Tables["OrderDetails"].Rows.Count; iRowID++)
		{
		  DataRow dRow = dsOD.Tables["OrderDetails"].Rows[iRowID];
		  dcmdIC.Parameters[0].Value = dRow["ProductID"].ToString();
		  cmdIC.Parameters[1].Value = dRow["UnitPrice"].ToString();
		  cmdIC.Parameters[2].Value = dRow["Quantity"].ToString();
		  cmdIC.Parameters[3].Value = dRow["Discount"].ToString();

		  iRowAff += cmdIC.ExecuteNonQuery();
		}

		MessageBox.Show("Order Details: rows affected - " + iRowAff.ToString());
	  }
	  catch (OleDbException exc) MessageBox.Show(exc.ToString());

	  }
	}
}
