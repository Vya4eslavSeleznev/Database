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
    private int customerId;

    public User(int customerId)
    {
      this.customerId = customerId;
      InitializeComponent();
      connection.Open();
      setOperation();

      firstNameTextBox.Text = Convert.ToString(customerId);
    }

    private void setOperation()
    {
      /*string strSQL =
        "SELECT Article.[Name], Currency.[Name], Balance.Number, " +
        "Operation.Cash, Operation.[Date], Operation.WhoseBalance " +
        "FROM Operation " +
        "JOIN Article " +
          "ON Operation.ArticleId = Article.ArticleId " +
        "JOIN Currency " +
          "ON Operation.CurrencyId = Currency.CurrencyId " +
        "JOIN Balance " +
          "ON Operation.BalanceId = Balance.BalanceId " +
        "WHERE CustomerId = " + customerId;*/

      /*string strSQL =
        "SELECT * " +
        "FROM Operation " +
        "JOIN Article " +
          "ON Operation.ArticleId = Article.ArticleId " +
        "JOIN Currency " +
          "ON Operation.CurrencyId = Currency.CurrencyId " +
        "JOIN Balance " +
          "ON Operation.BalanceId = Balance.BalanceId " +
        "WHERE CustomerId = " + customerId;*/

      /*string strSQL = "SELECT * FROM Operation WHERE BalanceId = (SELECT BalanceId FROM Balance " +
        "WHERE CustomerId = " + customerId + ")";*/

      string strSQL = "SELECT * FROM Operation";

      var da = new OleDbDataAdapter(strSQL, connection);
      DataTable tableCustomers = new DataTable("Operation");
      dsOperation.Tables.Add(tableCustomers);

      operationDataGridView.AutoGenerateColumns = true;
      operationDataGridView.DataSource = dsOperation;
      operationDataGridView.DataMember = "Operation";

      da.Fill(dsOperation, "Operation");
      operationDataGridView.DataMember = "Operation";
      Text = "Operation";
    }

    private void User_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
      Application.Exit();
    }
  }
}
