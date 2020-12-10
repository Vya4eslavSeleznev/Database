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
  public partial class EditCard : Form
  {
    private DataRow dRow;
    private DataTable dTable;
    private OleDbDataAdapter dAdapter;
    private readonly int cardId;
    private readonly int customerId;
    private readonly User userForm;

    public EditCard(int cardId, int customerId, User userForm)
    {
      InitializeComponent();
      connection.Open();
      this.cardId = cardId;
      this.customerId = customerId;
      this.userForm = userForm;
      SetComboBox();
      SetData();
    }

    private void EditCard_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
      this.userForm.RefreshCardDataGrid();
    }

    private void ShowRow()
    {
      dRow = dTable.Rows[0];

      cardBalanceIdComboBox.SelectedItem = GetSelectedItem((int)dRow["BalanceId"], cardBalanceIdComboBox.Items);
      cardNumberTextBox.Text = dRow["Number"].ToString();
    }

    private object GetSelectedItem(int selectedId, ComboBox.ObjectCollection items)
    {
      return items.Cast<IEntity>()
        .FirstOrDefault(x => x.Id == selectedId);
    }

    private void FillDataTable()
    {
      var card =
        " SELECT [Card].Number " +
        "FROM [Card] " +
        "JOIN BalanceCards ON[Card].CardId = BalanceCards.CardId " +
        "JOIN Balance ON BalanceCards.BalanceId = Balance.BalanceId " +
        "WHERE [Card].CardId = " + customerId;

      dAdapter = new OleDbDataAdapter(card, connection);
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
        "SELECT Balance.BalanceId, Balance.Number " +
        "FROM Balance " +
        "JOIN BalanceCards ON Balance.BalanceId = BalanceCards.BalanceId " +
        "WHERE BalanceCards.CardId = " + cardId, connection))

      using (var reader = cmd.ExecuteReader())
      {
        while (reader.Read())
          cardBalanceIdComboBox.Items.Add(new Article(reader.GetInt32(0), reader.GetString(1)));
      }
    }

    private void editCardButton_Click(object sender, EventArgs e)
    {
      var balance = ((Balance)cardBalanceIdComboBox.SelectedItem).Id;
      var cardNumber = cardNumberTextBox.Text;

      string updateCardQuery =
        "UPDATE Card " +
        "SET " +
          "Number = ? " +
        "WHERE CardId = ?";

      string updateBalanceCardQuery =
        "UPDATE BalanceCards " +
        "SET " +
          "BalanceId = ? " +
        "WHERE CardId = ?";

      OleDbCommand cardCmd = new OleDbCommand(updateCardQuery, connection);
      OleDbCommand balanceCardCmd = new OleDbCommand(updateBalanceCardQuery, connection);

      cardCmd.Parameters.Add(new OleDbParameter("@Number", cardNumber));
      cardCmd.Parameters.Add(new OleDbParameter("@CardId", cardId));

      balanceCardCmd.Parameters.Add(new OleDbParameter("@BalanceId", balance));
      balanceCardCmd.Parameters.Add(new OleDbParameter("@CardId", cardId));

      cardCmd.ExecuteNonQuery();
      balanceCardCmd.ExecuteNonQuery();
      MessageBox.Show("Card updated!", "Card", MessageBoxButtons.OK);
    }
  }
}
