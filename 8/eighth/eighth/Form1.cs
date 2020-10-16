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

namespace eighth
{
  public partial class Form1 : Form
  {
    private String strConn;
    private System.Data.OleDb.OleDbDataAdapter dAdapter;
    private System.Data.DataSet dSet;
    private System.Data.DataTable dTable;
    private System.Data.DataRow dRow;
    private int iRowID;

    public Form1()
    {
      InitializeComponent();

      iRowID = 0;
      strConn = "Provider=SQLNCLI11;Data Source=LAPTOP-V75FG2GF\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Company";
      cn.ConnectionString = strConn;
      dSet = new DataSet();

      cn.Close();

      DataTable dtTmp;
      dtTmp = dSet.Tables.Add("Order Details");
      dtTmp.Columns.Add("OrderID", typeof(int));
      dtTmp.Columns.Add("ProductID", typeof(int));
      dtTmp.Columns.Add("UnitPrice", typeof(Decimal));
      dtTmp.Columns.Add("Quantity", typeof(int));
      dtTmp.Columns.Add("Discount", typeof(Decimal));
      dtTmp.Columns.Add("ItemTotal", typeof(Decimal),
              "UnitPrice*Quantity*(1-Discount)");

      //dgOrderDetails.SetDataBinding(dSet, "Order Details");
      dgOrderDetails.DataSource = dtTmp;

      String strSQL = "SELECT * FROM Categories";

      dAdapter = new OleDbDataAdapter(strSQL, strConn);
      dAdapter.Fill(dSet, "Categories");

      //dgCategories.SetDataBinding(dSet, "Categories");
    }
    private void ShowRow()
    {
      dRow = dTable.Rows[iRowID];

      OrderID.Text = dRow["OrderID"].ToString();
      CustomerID.Text = dRow["CustomerID"].ToString();
      ShipName.Text = dRow["ShipName"].ToString();
      ShipCity.Text = dRow["ShipCity"].ToString();
      ShipCountry.Text = dRow["ShipCountry"].ToString();
    }

    private void showButton_Click(object sender, EventArgs e)
    {
      String strSQL = "SELECT OrderID, CustomerID, ShipName, " +
                        "ShipCity, ShipCountry FROM Orders";
      dAdapter = new OleDbDataAdapter(strSQL, strConn);
      dAdapter.Fill(dSet, "Orders");
      dTable = dSet.Tables["Orders"];
      ShowRow();
    }

    private void nextButton_Click(object sender, EventArgs e)
    {
      try
      {
        if (iRowID < dSet.Tables["Orders"].Rows.Count - 1)
        {
          iRowID++;
          ShowRow();
        }
      }
      catch (NullReferenceException)
      {
        return;
      }
    }

    private void BackButton_Click(object sender, EventArgs e)
    {
      if (iRowID > 0)
      {
        iRowID--;
        ShowRow();
      }
    }

    private void showOrderDetailsButton_Click(object sender, EventArgs e)
    {
      String strSQL = "SELECT * FROM [Order Details]";

      dAdapter = new OleDbDataAdapter(strSQL, strConn);
      dAdapter.Fill(dSet, "Order Details");
    }

    private void addButton_Click(object sender, EventArgs e)
    {
      dRow = dSet.Tables["Categories"].NewRow();

      dRow["CategoryName"] = CategoryName.Text;
      dRow["Description"] = Description.Text;
      dSet.Tables["Categories"].Rows.Add(dRow);
      MessageBox.Show("New record created in DataTable!");
    }

    private void firstButton_Click(object sender, EventArgs e)
    {
      iRowID = 0;
      ShowRow();
    }

    private void lastButton_Click(object sender, EventArgs e)
    {
      iRowID = dSet.Tables["Orders"].Rows.Count - 1;
      ShowRow();
    }
  }
}
