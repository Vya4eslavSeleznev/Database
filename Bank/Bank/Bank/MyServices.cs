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
        "SELECT CardServices.CardId, [Card].Number, CardService.[Name] " +
        "FROM CardService " +
        "JOIN CardServices ON CardService.CardServiceId = CardServices.ServiceId " +
        "JOIN[Card] ON CardServices.CardId = [Card].CardId " +
        "JOIN BalanceCards ON[Card].CardId = BalanceCards.CardId " +
        "JOIN Balance ON Balance.BalanceId = BalanceCards.BalanceId " +
        "WHERE Balance.CustomerId = " + customerId;

      this.userForm.addCheckBoxInDataGrid("Select to delete", myServicesDataGridView);
      this.userForm.setDataInTable(myServiceQuery, "Service", dsMyServices, myServicesDataGridView);
      this.userForm.addButtonInDataGrid(myServicesDataGridView, "Edit Service", "Edit");
      myServicesDataGridView.Columns["CardId"].Visible = false;
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
      List<int> cardServiceIds = null;

      try
      {
        cardServiceIds = (from DataGridViewRow r in myServicesDataGridView.Rows
                         where (string)r.Cells[0].Value == "1"
                         select (int)r.Cells["CardId"].Value).ToList();
      }
      catch
      {
        MessageBox.Show("Incorrect Service!", "Service", MessageBoxButtons.OK);
        return;
      }

      var parametersPart = string.Join(",", cardServiceIds.Select(x => "?"));
      var query = $"DELETE FROM CardServices WHERE CardId IN ({parametersPart})";

      using (var cmd = new OleDbCommand(query, connection))
      {
        for (var i = 0; i < cardServiceIds.Count; i++)
          cmd.Parameters.Add(new OleDbParameter($"@CardId{i}", cardServiceIds[i]));

        cmd.ExecuteNonQuery();
      }

      RefreshCardServiceDataGrid();
    }

    private void myServicesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      var senderGrid = (DataGridView)sender;

      if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
      {
        try
        {
          var cardId = (int)myServicesDataGridView["CardId", e.RowIndex].Value;

          using (var editService = new EditService(customerId))
          {
            editService.ShowDialog();
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show("Incorrect parameters!", "Service", MessageBoxButtons.OK);
        }
      }
    }
  }
}
