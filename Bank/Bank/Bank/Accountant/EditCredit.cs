using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using Bank.Models;

namespace Bank
{
  public partial class EditCredit : Form
  {
    private DataRow dRow;
    private DataTable dTable;
    private OleDbDataAdapter dAdapter;
    private readonly int creditInfoId;
    private readonly Accountant accountant;

    public EditCredit(int creditInfoId, Accountant accountant)
    {
      InitializeComponent();
      connection.Open();
      this.creditInfoId = creditInfoId;
      this.accountant = accountant;
      SetComboBox();
      SetData();
    }

    private void EditCredit_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
    }

    private void ShowRow()
    {
      dRow = dTable.Rows[0];

      creditCurrencyComboBox.SelectedItem = GetSelectedItem((int)dRow["CurrencyId"], creditCurrencyComboBox.Items);

      creditTermTextBox.Text = dRow["Term"].ToString();
      creditPercentTextBox.Text = dRow["Percent"].ToString();
      creditInfoTextBox.Text = dRow["Name"].ToString();
    }

    private object GetSelectedItem(int selectedId, ComboBox.ObjectCollection items)
    {
      return items.Cast<IEntity>()
        .FirstOrDefault(x => x.Id == selectedId);
    }

    private void FillDataTable()
    {
      var creditInfo =
        "SELECT InfoCredit.[Name], " +
        "Currency.CurrencyId, " +
        "InfoCredit.[Percent], " +
        "InfoCredit.Term " +
        "FROM InfoCredit " +
        "JOIN Currency ON InfoCredit.CurrencyId = Currency.CurrencyId " +
        "WHERE InfoCredit.InfoCreditId = " + creditInfoId;

      dAdapter = new OleDbDataAdapter(creditInfo, connection);
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
      using (var cmd = new OleDbCommand(
        "SELECT CurrencyId, [Name] FROM Currency", connection))

      using (var reader = cmd.ExecuteReader())
      {
        while (reader.Read())
          creditCurrencyComboBox.Items.Add(new Currency(reader.GetInt32(0), reader.GetString(1)));
      }
    }

    private void saveChangesButton_Click(object sender, EventArgs e)
    {
      var currency = ((Currency)creditCurrencyComboBox.SelectedItem).Id;
      var term = creditTermTextBox.Text;
      var percent = creditPercentTextBox.Text;
      var info = creditInfoTextBox.Text;

      string updateCreditInfoQuery =
        "UPDATE InfoCredit " +
        "SET " +
          "Name = ?, " +
          "CurrencyId = ?, " +
          "[Percent] = ?," +
          "Term = ? " +
          "WHERE InfoCreditId = ?";


      using (var creditInfoCmd = new OleDbCommand(updateCreditInfoQuery, connection))
      {
        creditInfoCmd.Parameters.Add(new OleDbParameter("@Name", info));
        creditInfoCmd.Parameters.Add(new OleDbParameter("@CurrencyId", currency));
        creditInfoCmd.Parameters.Add(new OleDbParameter("@Percent", percent));
        creditInfoCmd.Parameters.Add(new OleDbParameter("@Term", term));
        creditInfoCmd.Parameters.Add(new OleDbParameter("@Id", this.creditInfoId));

        creditInfoCmd.ExecuteNonQuery();
      }

      MessageBox.Show("Credit type updated!", "Credit type", MessageBoxButtons.OK);
      this.accountant.RefreshCreditInfoDataGrid();
    }
  }
}
