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
  public partial class EditCard : Form
  {
    private System.Data.DataRow dRow;
    private System.Data.DataTable dTable;
    private System.Data.OleDb.OleDbDataAdapter dAdapter;
    private int customerId;

    public EditCard(int customerId)
    {
      InitializeComponent();
      this.customerId = customerId;
      connection.Open();
      setData();
      setComboBox();
    }

    private void EditCard_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
    }

    private void ShowRow()
    {
      dRow = dTable.Rows[0];

      cardNumberTextBox.Text = dRow["Number"].ToString();
      cardServiceComboBox.Text = dRow["Service"].ToString();
    }

    private void FillDataTable()
    {
      var card =
        "SELECT [Card].Number, CardService.[Name] AS Service " +
        "FROM [Card] " +
        "JOIN CardServices ON [Card].CardId = CardServices.CardId " +
        "JOIN CardService ON CardServices.ServiceId = CardService.CardServiceId " +
        "JOIN BalanceCards ON [Card].CardId = BalanceCards.BalanceId " +
        "JOIN Balance ON BalanceCards.BalanceId = Balance.BalanceId " +
        "WHERE Balance.CustomerId = " + customerId;

      dAdapter = new OleDbDataAdapter(card, connection);
      dTable = new DataTable();
      dAdapter.Fill(dTable);
    }

    private void setData()
    {
      FillDataTable();
      ShowRow();
    }

    private void setComboBox()
    {
      OleDbCommand command = new OleDbCommand("SELECT CardServiceId, [Name] FROM CardService", connection);
      OleDbDataReader rdr = command.ExecuteReader();
      while (rdr.Read())
        cardServiceComboBox.Items.Add(rdr["CardServiceId"] + " - " + rdr["Name"]);
      rdr.Close();
    }

    private void editCardButton_Click(object sender, EventArgs e)
    {
     
    }
  }
}
