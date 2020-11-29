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

namespace Bank
{
  public partial class User : Form
  {

    public User()
    {
      InitializeComponent();
      connection.Open();

      var da = new OleDbDataAdapter("SELECT * FROM Operation", connection);
      DataTable tableCustomers = new DataTable("Operation");
      dsOperation.Tables.Add(tableCustomers);

      operationDataGridView.AutoGenerateColumns = true;
      operationDataGridView.DataSource = dsOperation;
      operationDataGridView.DataMember = "Operation";

      da.Fill(dsOperation, "Operation");
      operationDataGridView.DataMember = "Operation";
     // Text = "Operation";

    }

    private void User_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
    }
  }
}
