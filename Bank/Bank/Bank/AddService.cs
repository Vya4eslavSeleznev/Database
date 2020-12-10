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
  public partial class AddService : Form
  {
    private int customerId;
    private int cardId;

    public AddService(int cardId, int customerId)
    {
      InitializeComponent();
      connection.Open();
      this.customerId = customerId;
      this.cardId = cardId;
      SetComboBox();
    }

    private void AddService_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
    }

    private void SetComboBox()
    {
      using (var cmd = new OleDbCommand(
        "SELECT CardServiceId, [Name] " +
        "FROM CardService", connection))

      using (var reader = cmd.ExecuteReader())
      {
        while (reader.Read())
          cardServiceComboBox.Items.Add(new Service(reader.GetInt32(0), reader.GetString(1)));
      }

      using (var cmd = new OleDbCommand(
        "SELECT [Card].CardId, [Card].Number " +
        "FROM[Card] " +
        "JOIN BalanceCards ON[Card].CardId = BalanceCards.CardId " +
        "WHERE BalanceCards.CardId = " + cardId, connection))

      using (var reader = cmd.ExecuteReader())
      {
        while (reader.Read())
          cardComboBox.Items.Add(new Card(reader.GetInt32(0), reader.GetString(1)));
      }
    }

    private void addServiceButton_Click(object sender, EventArgs e)
    {
      var card = ((Card)cardComboBox.SelectedItem).Id;
      var service = ((Service)cardServiceComboBox.SelectedItem).Id;

      string addServiceQuery =
        "INSERT INTO CardServices (CardId, ServiceId) " +
        "VALUES(?, ?)";

      OleDbCommand addServiceCmd = new OleDbCommand(addServiceQuery, connection);
      addServiceCmd.Parameters.Add(new OleDbParameter("@CardId", card));
      addServiceCmd.Parameters.Add(new OleDbParameter("@ServiceId", service));

      addServiceCmd.ExecuteNonQuery();
      MessageBox.Show("Service added!", "Service", MessageBoxButtons.OK);
    }
  }
}
