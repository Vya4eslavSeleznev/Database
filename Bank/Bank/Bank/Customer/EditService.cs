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
  public partial class EditService : Form
  {
    private int customerId;
    private DataRow dRow;
    private DataTable dTable;
    private OleDbDataAdapter dAdapter;

    public EditService(int customerId)
    {
      InitializeComponent();
      connection.Open();
      this.customerId = customerId;
      SetComboBox();
      SetData();
    }

    private void EditService_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
    }

    private void SetComboBox()
    {
      using (var cmd = new OleDbCommand("SELECT CardServiceId, [Name] FROM CardService", connection))
      using (var reader = cmd.ExecuteReader())
      {
        while (reader.Read())
          cardServiceComboBox.Items.Add(new Service(reader.GetInt32(0), reader.GetString(1)));
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





    private void ShowRow()
    {
      dRow = dTable.Rows[0];

      cardComboBox.SelectedItem = GetSelectedItem((int)dRow["CardId"], cardComboBox.Items);
      cardServiceComboBox.SelectedItem = GetSelectedItem((int)dRow["CardServiceId"], cardServiceComboBox.Items);
    }

    private object GetSelectedItem(int selectedId, ComboBox.ObjectCollection items)
    {
      return items.Cast<IEntity>()
        .FirstOrDefault(x => x.Id == selectedId);
    }

    private void FillDataTable()
    {
      var service =
        "SELECT CardServices.CardId, [Card].Number, CardService.[Name] " +
        "FROM [Card] " +
        "JOIN CardServices ON [Card].CardId = CardServices.CardId " +
        "JOIN CardService ON CardServices.ServiceId = CardService.CardServiceId " +
        "JOIN BalanceCards ON[Card].CardId = BalanceCards.CardId " +
        "JOIN Balance ON BalanceCards.BalanceId = Balance.BalanceId " +
        "WHERE Balance.CustomerId = " + customerId;

      dAdapter = new OleDbDataAdapter(service, connection);
      dTable = new DataTable();
      dAdapter.Fill(dTable);
    }

    private void SetData()
    {
      FillDataTable();
      ShowRow();
    }
  }
}
