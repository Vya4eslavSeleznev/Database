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
  public partial class EditOperation : Form
  {
    private System.Data.DataRow dRow;
    private System.Data.DataTable dTable;
    private System.Data.OleDb.OleDbDataAdapter dAdapter;
    private int operationId;
    private DataSet dsOperation;
    private int customerId;
    private string query;
    private DataGridView dataGridView;

    public EditOperation(DataSet dsOperation, int operationId, int customerId,
                         string query, DataGridView dataGridView)
    {
      InitializeComponent();
      connection.Open();
      this.dsOperation = dsOperation;
      this.operationId = operationId;
      this.customerId = customerId;
      this.query = query;
      this.dataGridView = dataGridView;
      setData();
      setComboBox();
    }

    private void ShowRow()
    {
      dRow = dTable.Rows[0];

      //articleComboBox.Text = dRow["ArticleId"].ToString();
      //currencyOperationComboBox.Text = dRow["CurrencyId"].ToString();

      articleComboBox.Text = dRow["Article"].ToString();
      currencyOperationComboBox.Text = dRow["Currency"].ToString();
      balanceIdComboBox.Text = dRow["BalanceId"].ToString();
      operationCashTextBox.Text = dRow["Cash"].ToString();
      dateOfOperationPicker.Text = dRow["Date"].ToString();
      whoseBalanceTextBox.Text = dRow["WhoseBalance"].ToString();
    }

    private void FillDataTable()
    {
      var operation =
        "SELECT Article.[Name] AS Article, " +
        "Currency.[Name] AS Currency, " +
        "Balance.Number, " +
        "Balance.BalanceId, " +
        "Operation.Cash, " +
        "Operation.[Date], " +
        "Operation.WhoseBalance " +
        "FROM Operation " +
        "JOIN Article " +
        "ON Operation.ArticleId = Article.ArticleId " +
        "JOIN Currency " +
        "ON Operation.CurrencyId = Currency.CurrencyId " +
        "JOIN Balance " +
        "ON Operation.BalanceId = Balance.BalanceId " +
        "WHERE Operation.OperationId = " + operationId;

      dAdapter = new OleDbDataAdapter(operation, connection);
      dTable = new DataTable();
      dAdapter.Fill(dTable);
    }

    private void setData()
    {
      FillDataTable();
      ShowRow();
    }

    private void parseComboBox(int index, string data, OleDbCommand cmdIC)
    {
      cmdIC.Parameters[index].Value = data.Remove(data.IndexOf("-") - 1,
        data.Length - data.IndexOf("-") + 1);
    }

    private void editOperationButton_Click(object sender, EventArgs e)
    {
      var articleId = articleComboBox.Text;
      var currencyId = currencyOperationComboBox.Text;
      var balanceId = balanceIdComboBox.Text;
      var cash = operationCashTextBox.Text;
      var date = dateOfOperationPicker.Value.Date.ToString("yyyy - MM - dd");
      var whoseBalance = whoseBalanceTextBox.Text;

      string updateProfileQuery =
        "UPDATE Operation " +
        "SET " +
          "ArticleId = ?, " +
          "CurrencyId = ?, " +
          "BalanceId = ?, " +
          "Cash = ?, " +
          "Date = ?, " +
          "WhoseBalance = ? " +
        "WHERE OperationId = ?";

      OleDbCommand cmdIC = new OleDbCommand(updateProfileQuery, connection);

      cmdIC.Parameters.Add(new OleDbParameter("@ArticleId", articleId));
      cmdIC.Parameters.Add(new OleDbParameter("@CurrencyId", currencyId));
      cmdIC.Parameters.Add(new OleDbParameter("@BalanceId", balanceId));
      cmdIC.Parameters.Add(new OleDbParameter("@Cash", cash));
      cmdIC.Parameters.Add(new OleDbParameter("@Date", date));
      cmdIC.Parameters.Add(new OleDbParameter("@WhoseBalance", whoseBalance));
      cmdIC.Parameters.Add(new OleDbParameter("@OperationId", operationId));

      parseComboBox(0, articleId, cmdIC);
      parseComboBox(1, currencyId, cmdIC);
      parseComboBox(2, balanceId, cmdIC);

      cmdIC.ExecuteNonQuery();
      MessageBox.Show("Operation updated!", "Operation", MessageBoxButtons.OK);
    }

    private void setComboBox()
    {
      OleDbCommand command = new OleDbCommand("SELECT ArticleId, [Name] FROM Article", connection);
      OleDbDataReader rdr = command.ExecuteReader();
      while (rdr.Read())
        articleComboBox.Items.Add(rdr["ArticleId"] + " - " + rdr["Name"]);
      rdr.Close();

      command.CommandText = "SELECT CurrencyId, [Name] FROM Currency";
      rdr = command.ExecuteReader();
      while (rdr.Read())
        currencyOperationComboBox.Items.Add(rdr["CurrencyId"] + " - " + rdr["Name"]);
      rdr.Close();

      command.CommandText = "SELECT BalanceId, Number FROM Balance WHERE CustomerId = ?";
      command.Parameters.Add(new OleDbParameter("@CustomerId", customerId));
      rdr = command.ExecuteReader();

      while (rdr.Read())
        balanceIdComboBox.Items.Add(rdr["BalanceId"] + " - " + rdr["Number"]);

      rdr.Close();
    }

    private void refreshDataSet(string query, DataSet ds, string table)
    {
      var command = new OleDbCommand(query, connection);
      var dataAdapter = new OleDbDataAdapter(command);
      dataAdapter.Fill(ds.Tables[0]);
    }

    private void EditOperation_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
      refreshDataSet(query, dsOperation, "Opeartion");
    }
  }
}
