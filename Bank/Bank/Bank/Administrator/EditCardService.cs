using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using Bank.Models;

namespace Bank
{
  public partial class EditCardService : Form
  {
    private DataRow dRow;
    private DataTable dTable;
    private OleDbDataAdapter dAdapter;
    private readonly int cardServiceId;
    private readonly Admin admin;

    public EditCardService(int cardServiceId, Admin admin)
    {
      InitializeComponent();
      connection.Open();
      this.cardServiceId = cardServiceId;
      this.admin = admin;
      SetData();
    }

    private void EditCardService_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
    }


    private void ShowRow()
    {
      dRow = dTable.Rows[0];

      cardServiceTextBox.Text = dRow["Name"].ToString();
      servicePriceNumericUpDown.Text = dRow["Price"].ToString();
    }

    private object GetSelectedItem(int selectedId, ComboBox.ObjectCollection items)
    {
      return items.Cast<IEntity>()
        .FirstOrDefault(x => x.Id == selectedId);
    }

    private void FillDataTable()
    {
      var cardService = $"SELECT [Name], Price FROM CardService WHERE CardServiceId = {cardServiceId}";

      dAdapter = new OleDbDataAdapter(cardService, connection);
      dTable = new DataTable();
      dAdapter.Fill(dTable);
    }

    private void SetData()
    {
      FillDataTable();
      ShowRow();
    }

    private void editServiceButton_Click(object sender, EventArgs e)
    {
      var name = cardServiceTextBox.Text;
      var price = servicePriceNumericUpDown.Text;

      string updateCreditInfoQuery =
        "UPDATE CardService " +
        "SET " +
          "Name = ?, " +
          "Price = ? " +
          "WHERE CardServiceId = ?";


      using (var cardServiceCmd = new OleDbCommand(updateCreditInfoQuery, connection))
      {
        cardServiceCmd.Parameters.Add(new OleDbParameter("@Name", name));
        cardServiceCmd.Parameters.Add(new OleDbParameter("@Price", price));
        cardServiceCmd.Parameters.Add(new OleDbParameter("@CardServiceId", cardServiceId));
        cardServiceCmd.ExecuteNonQuery();
      }

      MessageBox.Show("Card Service updated!", "Card Service", MessageBoxButtons.OK);

      this.admin.RefreshCardServiceDataGrid();
    }
  }
}
