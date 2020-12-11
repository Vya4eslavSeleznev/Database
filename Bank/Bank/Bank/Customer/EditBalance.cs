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
using Bank.Models;

namespace Bank
{
  public partial class EditBalance : Form
  {
    private DataRow dRow;
    private DataTable dTable;
    private OleDbDataAdapter dAdapter;
    private readonly int balanceId;
    private readonly int customerId;
    private readonly User userForm;

    public EditBalance(int balanceId, int customerId, User userForm)
    {
      InitializeComponent();
      connection.Open();
      this.balanceId = balanceId;
      this.customerId = customerId;
      this.userForm = userForm;
      SetComboBox();
      SetData();
    }

    private void EditBalance_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
      this.userForm.RefreshBalanceDataGrid();
    }

    private void ShowRow()
    {
      dRow = dTable.Rows[0];

      cardComboBox.SelectedItem = GetSelectedItem((int)dRow["Number"], cardComboBox.Items);
      currencyBalanceComboBox.SelectedItem = GetSelectedItem((int)dRow["CurrencyId"], currencyBalanceComboBox.Items);

      balanceNumTextBox.Text = dRow["Number"].ToString();
      balanceDatePicker.Text = dRow["Date"].ToString();
      balanceCashTextBox.Text = dRow["Cash"].ToString();
    }

    private object GetSelectedItem(int selectedId, ComboBox.ObjectCollection items)
    {
      return items.Cast<IEntity>()
        .FirstOrDefault(x => x.Id == selectedId);
    }

    private void FillDataTable()
    {
      var balance = this.userForm.myBalance();

      dAdapter = new OleDbDataAdapter(balance, connection);
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
          currencyBalanceComboBox.Items.Add(new Currency(reader.GetInt32(0), reader.GetString(1)));
      }

      using (var cmd = new OleDbCommand(
        "SELECT [Card].CardId, [Card].Number " +
        "FROM [Card] " +
        "JOIN BalanceCards ON [Card].CardId = BalanceCards.CardId " +
        "JOIN Balance ON BalanceCards.BalanceId = Balance.BalanceId " +
        "WHERE Balance.CustomerId = " + customerId, connection))

      using (var reader = cmd.ExecuteReader())
      {
        while (reader.Read())
          cardComboBox.Items.Add(new Card(reader.GetInt32(0), reader.GetString(1)));
      }
    }
  }
}
