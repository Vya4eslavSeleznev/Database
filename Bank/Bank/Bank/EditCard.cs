using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank
{
  public partial class EditCard : Form
  {
    private System.Data.DataRow dRow;
    private System.Data.DataTable dTable;

    public EditCard()
    {
      InitializeComponent();
      connection.Open();
    }

    private void EditCard_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
    }

    /*private void ShowRow()
    {
      dRow = dTable.Rows[0];

      //articleComboBox.Text = dRow["ArticleId"].ToString();
      //currencyOperationComboBox.Text = dRow["CurrencyId"].ToString();

      cardNumberTextBox.Text = dRow["Article"].ToString();
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
    }*/
  }
}
