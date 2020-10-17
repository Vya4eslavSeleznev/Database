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

      cn.Open();

      DataTable dtTmp;
      dtTmp = dSet.Tables.Add("Order Details");
      dtTmp.Columns.Add("OrderID", typeof(int));
      dtTmp.Columns.Add("ProductID", typeof(int));
      dtTmp.Columns.Add("UnitPrice", typeof(Decimal));
      dtTmp.Columns.Add("Quantity", typeof(int));
      dtTmp.Columns.Add("Discount", typeof(Decimal));
      dtTmp.Columns.Add("ItemTotal", typeof(Decimal),
              "UnitPrice*Quantity*(1-Discount)");

      dgOrderDetails.DataSource = dtTmp;

      string strSQL = "SELECT * FROM Categories";

      dAdapter = new OleDbDataAdapter(strSQL, strConn);
      dAdapter.Fill(dSet, "Categories");

      dgCategories.AutoGenerateColumns = true;
      dgCategories.DataSource = dSet;
      dgCategories.DataMember = "Categories";
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

    private void FillDataTable()
    {
      var strSQL = "SELECT OrderID, CustomerID, ShipName, " +
                        "ShipCity, ShipCountry FROM Orders";
      dAdapter = new OleDbDataAdapter(strSQL, strConn);
      dAdapter.Fill(dSet, "Orders");
      dTable = dSet.Tables["Orders"];
    }

    private void showButton_Click(object sender, EventArgs e)
    {
      FillDataTable();
      ShowRow();
    }

    private void nextButton_Click(object sender, EventArgs e)
    {
      if (dTable == null)
        FillDataTable();

      if (iRowID < dSet.Tables["Orders"].Rows.Count - 1)
      {
        iRowID++;
        ShowRow();
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

    private int count = 0;

    private void showOrderDetailsButton_Click(object sender, EventArgs e)
    {
      String strSQL = "SELECT * FROM [Order Details]";

      dAdapter = new OleDbDataAdapter(strSQL, strConn);

      if (count == 0)
      {
        dAdapter.Fill(dSet, "Order Details");
        count++;
      }
    }

    private void addButton_Click(object sender, EventArgs e)
    {
      dRow = dSet.Tables["Categories"].NewRow();

      if (CategoryName.Text == "" || Description.Text == "")
      {
        MessageBox.Show("Empty value");
        return;
      }

      dRow["CategoryName"] = CategoryName.Text;
      dRow["Description"] = Description.Text;
      dSet.Tables["Categories"].Rows.Add(dRow);

      var sql = "INSERT INTO Categories (CategoryName, Description) VALUES (?, ?)";
      //$"('{CategoryName.Text}', '{Description.Text}')";

      using (var cmd = new OleDbCommand(sql, cn))
      {
        cmd.Parameters.Add("@p1", OleDbType.VarChar, 50);
        cmd.Parameters.Add("@p1", OleDbType.VarChar, 50);

        cmd.Parameters[0].Value = CategoryName.Text;
        cmd.Parameters[1].Value = Description.Text;

        cmd.ExecuteNonQuery();
      }

      dSet.AcceptChanges();
      MessageBox.Show("New record created in DataTable!");
    }

    private void firstButton_Click(object sender, EventArgs e)
    {
      if (dTable == null)
        FillDataTable();

      iRowID = 0;
      ShowRow();
    }

    private void lastButton_Click(object sender, EventArgs e)
    {
      if (dTable == null)
        FillDataTable();

      iRowID = dSet.Tables["Orders"].Rows.Count - 1;
      ShowRow();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      cn.Close();
    }
  }
}
