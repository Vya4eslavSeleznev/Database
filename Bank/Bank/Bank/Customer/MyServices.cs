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
  public partial class MyServices : Form
  {
    private readonly User userForm;
    private int customerId;

    public MyServices(User userForm, int customerId)
    {
      InitializeComponent();
      connection.Open();
      this.userForm = userForm;
      this.customerId = customerId;
      setService();
    }

    private void setService()
    {
      string myServiceQuery =
        "SELECT CardService.CardServiceId, " +
        "[Card].CardId, " +
        "[Card].Number AS 'Card Number', " +
        "CardService.[Name] AS 'Service Name'" +
        "FROM CardService " +
        "JOIN CardServices ON CardService.CardServiceId = CardServices.ServiceId " +
        "JOIN [Card] ON CardServices.CardId = [Card].CardId " +
        "JOIN BalanceCards ON[Card].CardId = BalanceCards.CardId " +
        "JOIN Balance ON Balance.BalanceId = BalanceCards.BalanceId " +
        "WHERE Balance.CustomerId = " + customerId;

      this.userForm.addCheckBoxInDataGrid("Select to delete", myServicesDataGridView);
      this.userForm.setDataInTable(myServiceQuery, "Service", dsMyServices, myServicesDataGridView);
      myServicesDataGridView.Columns["CardId"].Visible = false;
      myServicesDataGridView.Columns["CardServiceId"].Visible = false;
    }

    public void RefreshCardServiceDataGrid()
    {
      myServicesDataGridView.Columns.Clear();
      dsMyServices = new DataSet();
      setService();
    }

    private void MyServices_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
    }

    private void deleteMyServiceButton_Click(object sender, EventArgs e)
    {
      try
      {
        var cardServices = (from DataGridViewRow r in myServicesDataGridView.Rows
                            where (string)r.Cells[0].Value == "1"
                            select new
                            {
                              CardId = (int)r.Cells["CardId"].Value,
                              ServiceId = (int)r.Cells["CardServiceId"].Value
                            })
                            .GroupBy(x => x.CardId)
                            .ToDictionary(x => x.Key, x => x.Select(y => y.ServiceId).ToList());

        foreach (var cardService in cardServices)
        {
          var serviceIdsParameters = string.Join(",", cardService.Value.Select(x => "?"));

          var query = $"DELETE FROM CardServices WHERE CardId = ? AND ServiceId IN ({serviceIdsParameters})";

          using (var cmd = new OleDbCommand(query, connection))
          {
            cmd.Parameters.Add(new OleDbParameter("@CardId", cardService.Key));

            for (var i = 0; i < cardService.Value.Count; i++)
              cmd.Parameters.Add(new OleDbParameter($"@CardServiceId{i}", cardService.Value[i]));

            cmd.ExecuteNonQuery();
          }
        }
      }
      catch
      {
        MessageBox.Show("Incorrect Service!", "Service", MessageBoxButtons.OK);
        return;
      }

      RefreshCardServiceDataGrid();
    }
  }
}
