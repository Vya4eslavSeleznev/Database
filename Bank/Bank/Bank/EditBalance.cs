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
  public partial class EditBalance : Form
  {
    private System.Data.DataRow dRow;
    private System.Data.DataTable dTable;
    private System.Data.OleDb.OleDbDataAdapter dAdapter;
    private int customerId;

    public EditBalance(int customerId)
    {
      InitializeComponent();
      connection.Open();
      this.customerId = customerId;
      setData();
    }

    private void EditBalance_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
    }

    private void ShowRow()
    {
      dRow = dTable.Rows[0];

      balanceNumTextBox.Text = dRow["Number"].ToString();
      balanceDatePicker.Text = dRow["Date"].ToString();
      currencyBalanceComboBox.Text = dRow["CurrencyId"].ToString();
      balanceCashTextBox.Text = dRow["Cash"].ToString();
      cardComboBox.Text = dRow["Card"].ToString();
    }

    private void FillDataTable()
    {
      var balance =
        "SELECT Balance.Number, Balance.[Date], Currency.[Name], " +
        "Balance.Cash " +
        "FROM Balance " +
        "JOIN Currency ON Balance.CurrencyId = Currency.CurrencyId " +
        "WHERE CustomerId = " + customerId;

      dAdapter = new OleDbDataAdapter(balance, connection);
      dTable = new DataTable();
      dAdapter.Fill(dTable);
    }

    private void setData()
    {
      FillDataTable();
      ShowRow();
    }
  }
}
