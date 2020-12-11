using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using Bank.Models;

namespace Bank
{
  public partial class EditSecurity : Form
  {
    private DataRow dRow;
    private DataTable dTable;
    private OleDbDataAdapter dAdapter;
    private readonly int securityInfoId;
    private readonly Accountant accountant;

    public EditSecurity(int securityInfoId, Accountant accountant)
    {
      InitializeComponent();
      connection.Open();
      this.securityInfoId = securityInfoId;
      this.accountant = accountant;
      SetComboBox();
      SetData();
    }

    private void EditSecurity_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
    }

    private void ShowRow()
    {
      dRow = dTable.Rows[0];

      securityCurrencyComboBox.SelectedItem = GetSelectedItem((int)dRow["CurrencyId"], securityCurrencyComboBox.Items);

      securityNameTextBox.Text = dRow["Name"].ToString();
      securityPriceTextBox.Text = dRow["Price"].ToString();
      percentTextBox.Text = dRow["Percent"].ToString();
    }

    private object GetSelectedItem(int selectedId, ComboBox.ObjectCollection items)
    {
      return items.Cast<IEntity>()
        .FirstOrDefault(x => x.Id == selectedId);
    }

    private void FillDataTable()
    {
      var securityInfo =
        "SELECT Currency.CurrencyId, " +
        "InfoSecurities.[Name], " +
        "InfoSecurities.Price, " +
        "InfoSecurities.[Percent rate] AS 'Percent' " +
        "FROM InfoSecurities " +
        "JOIN Currency ON InfoSecurities.CurrencyId = InfoSecurities.CurrencyId " +
        "WHERE InfoSecurities.InfoSecuritiesId = " + securityInfoId;

      dAdapter = new OleDbDataAdapter(securityInfo, connection);
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
          securityCurrencyComboBox.Items.Add(new Currency(reader.GetInt32(0), reader.GetString(1)));
      }
    }

    private void saveChangesButton_Click(object sender, EventArgs e)
    {
      var currency = ((Currency)securityCurrencyComboBox.SelectedItem).Id;
      var name = securityNameTextBox.Text;
      var price = securityPriceTextBox.Text;
      var percent = percentTextBox.Text;

      string updateCreditInfoQuery =
        "UPDATE InfoSecurities " +
        "SET " +
          "CurrencyId = ?, " +
          "Name = ?, " +
          "Price = ?," +
          "[Percent rate] = ? " +
          "WHERE InfoSecuritiesId = ?";


      using (var securityInfoCmd = new OleDbCommand(updateCreditInfoQuery, connection))
      {
        securityInfoCmd.Parameters.Add(new OleDbParameter("@CurrencyId", currency));
        securityInfoCmd.Parameters.Add(new OleDbParameter("@Name", name));
        securityInfoCmd.Parameters.Add(new OleDbParameter("@Price", price));
        securityInfoCmd.Parameters.Add(new OleDbParameter("@PercentRate", percent));
        securityInfoCmd.Parameters.Add(new OleDbParameter("@Id", this.securityInfoId));

        securityInfoCmd.ExecuteNonQuery();
      }

      MessageBox.Show("Security type updated!", "Security type", MessageBoxButtons.OK);

      this.accountant.RefreshSecurityInfoDataGrid();
    }
  }
}
