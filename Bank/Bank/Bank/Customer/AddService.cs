using System;
using System.Windows.Forms;
using System.Data.OleDb;
using Bank.Models;

namespace Bank
{
  public partial class AddService : Form
  {
    private int cardId;

    public AddService(int cardId)
    {
      InitializeComponent();
      connection.Open();
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
    }

    private void addServiceButton_Click(object sender, EventArgs e)
    {
      var service = ((Service)cardServiceComboBox.SelectedItem).Id;

      string addServiceQuery =
        "INSERT INTO CardServices (CardId, ServiceId) " +
        "VALUES(?, ?)";

      OleDbCommand addServiceCmd = new OleDbCommand(addServiceQuery, connection);
      addServiceCmd.Parameters.Add(new OleDbParameter("@CardId", cardId));
      addServiceCmd.Parameters.Add(new OleDbParameter("@ServiceId", service));

      addServiceCmd.ExecuteNonQuery();
      MessageBox.Show("Service added!", "Service", MessageBoxButtons.OK);
    }
  }
}
