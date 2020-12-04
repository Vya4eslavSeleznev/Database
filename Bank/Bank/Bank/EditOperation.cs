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
    private int iRowID;
    private System.Data.OleDb.OleDbDataAdapter dAdapter;
    private int operationId;
    private DataSet dsOperation;

    public EditOperation(DataSet dsOperation, int operationId)
    {
      InitializeComponent();
      this.dsOperation = dsOperation;
      this.operationId = operationId;
      setData();
    }

    private void ShowRow()
    {
      dRow = dTable.Rows[iRowID];

      articleComboBox.Text = dRow["ArticleId"].ToString();
      currencyOperationComboBox.Text = dRow["CurrencyId"].ToString();
      balanceIdComboBox.Text = dRow["BalanceId"].ToString();
      operationCashTextBox.Text = dRow["Cash"].ToString();
      dateOfOperationPicker.Text = dRow["Date"].ToString();
      whoseBalanceTextBox.Text = dRow["WhoseBalance"].ToString();
    }

    private void FillDataTable()
    {
      var operation =
        "SELECT Article.[Name] AS Article, Currency.[Name] AS Currency, Balance.Number, " +
        "Operation.Cash, Operation.[Date], Operation.WhoseBalance " +
        "FROM Operation " +
        "JOIN Article " +
        "ON Operation.ArticleId = Article.ArticleId " +
        "JOIN Currency " +
        "ON Operation.CurrencyId = Currency.CurrencyId " +
        "JOIN Balance " +
        "ON Operation.BalanceId = Balance.BalanceId " +
        "WHERE Operation.OperationId = " + operationId;

      dAdapter = new OleDbDataAdapter(operation, connection);
      dAdapter.Fill(dsOperation, "Operation");
      dTable = dsOperation.Tables["Operation"];
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
      var date = dateOfOperationPicker.Value.Date.ToString("yyyy / MM / dd");
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
        "JOIN Balance ON Operation.BalanceId = Balance.BalanceId " +
        "WHERE OperaionId = ?";

      OleDbCommand cmdIC = new OleDbCommand(updateProfileQuery, connection);

      cmdIC.Parameters.Add(new OleDbParameter("@ArticleId", articleId));
      cmdIC.Parameters.Add(new OleDbParameter("@CurrencyId", currencyId));
      cmdIC.Parameters.Add(new OleDbParameter("@BalanceId", balanceId));
      cmdIC.Parameters.Add(new OleDbParameter("@Cash", cash));
      cmdIC.Parameters.Add(new OleDbParameter("@Date", date));
      cmdIC.Parameters.Add(new OleDbParameter("@WhoseBalance", whoseBalance));

      cmdIC.ExecuteNonQuery();
      MessageBox.Show("Operation updated!", "Operation", MessageBoxButtons.OK);
    }
  }
}
