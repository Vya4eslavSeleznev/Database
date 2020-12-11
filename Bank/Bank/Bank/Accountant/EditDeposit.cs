using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using Bank.Models;

namespace Bank
{
  public partial class EditDeposit : Form
  {
    private DataRow dRow;
    private DataTable dTable;
    private OleDbDataAdapter dAdapter;

    private readonly int depositInfoId;
    private readonly Accountant accountant;

    public EditDeposit(int depositInfoId, Accountant accountant)
    {
      InitializeComponent();
      connection.Open();
      this.depositInfoId = depositInfoId;
      this.accountant = accountant;
      SetComboBox();
      SetData();
    }

    private void EditDeposit_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
    }

    private void ShowRow()
    {
      dRow = dTable.Rows[0];

      currencyDepositComboBox.SelectedItem = GetSelectedItem((int)dRow["CurrencyId"], currencyDepositComboBox.Items);

      depositTermTextBox.Text = dRow["Term"].ToString();
      amountDepositTextBox.Text = dRow["Amount"].ToString();
      depositPercentTextBox.Text = dRow["Percent"].ToString();
      depositInfoTextBox.Text = dRow["DepositName"].ToString();
    }

    private object GetSelectedItem(int selectedId, ComboBox.ObjectCollection items)
    {
      return items.Cast<IEntity>()
        .FirstOrDefault(x => x.Id == selectedId);
    }

    private void FillDataTable()
    {
      var depositInfo =
        "SELECT " +
        "Currency.CurrencyId, " +
        "InfoDeposit.Term, " +
        "InfoDeposit.Amount, " +
        "InfoDeposit.[Percent], " +
        "InfoDeposit.DepositName " +
        "FROM InfoDeposit " +
        "JOIN Currency ON InfoDeposit.CurrencyId = Currency.CurrencyId " +
        "WHERE InfoDeposit.InfoDepositId = " + depositInfoId;

      dAdapter = new OleDbDataAdapter(depositInfo, connection);
      dTable = new DataTable();
      dAdapter.Fill(dTable);
    }

    private void SetData()
    {
      FillDataTable();
      ShowRow();
    }

    private void SetComboBox()
    {
      using (var cmd = new OleDbCommand("SELECT CurrencyId, [Name] FROM Currency", connection))
      using (var reader = cmd.ExecuteReader())
      {
        while (reader.Read())
          currencyDepositComboBox.Items.Add(new Currency(reader.GetInt32(0), reader.GetString(1)));
      }
    }

    private void saveChangesButton_Click(object sender, EventArgs e)
    {
      var currency = ((Currency)currencyDepositComboBox.SelectedItem).Id;
      var depositTerm = depositTermTextBox.Text;
      var amount = amountDepositTextBox.Text;
      var percent = depositPercentTextBox.Text;
      var info = depositInfoTextBox.Text;

      string updateDepositInfoQuery =
        "UPDATE InfoDeposit " +
        "SET " +
          "CurrencyId = ?, " +
          "Term = ?, " +
          "Amount = ?, " +
          "[Percent] = ?," +
          "DepositName = ? " +
          "WHERE InfoDepositId = ?";

      using (var depositInfoCmd = new OleDbCommand(updateDepositInfoQuery, connection))
      {
        depositInfoCmd.Parameters.Add(new OleDbParameter("@CurrencyId", currency));
        depositInfoCmd.Parameters.Add(new OleDbParameter("@Term", depositTerm));
        depositInfoCmd.Parameters.Add(new OleDbParameter("@Amount", amount));
        depositInfoCmd.Parameters.Add(new OleDbParameter("@Percent", percent));
        depositInfoCmd.Parameters.Add(new OleDbParameter("@DepositName", info));
        depositInfoCmd.Parameters.Add(new OleDbParameter("@Id", this.depositInfoId));

        depositInfoCmd.ExecuteNonQuery();
      }

      MessageBox.Show("Deposit type updated!", "Deposit type", MessageBoxButtons.OK);

      this.accountant.RefreshDepositInfoDataGrid();
    }
  }
}
