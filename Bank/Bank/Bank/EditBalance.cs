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
      //SetComboBox();
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

      balanceNumTextBox.Text = dRow["Number"].ToString();
      balanceDatePicker.Text = dRow["Date"].ToString();
      currencyBalanceComboBox.SelectedItem = GetSelectedItem((int)dRow["CurrencyId"], currencyBalanceComboBox.Items);
      balanceCashTextBox.Text = dRow["Cash"].ToString();
      cardComboBox.SelectedItem = GetSelectedItem((int)dRow["CardId"], cardComboBox.Items);
    }

    private object GetSelectedItem(int selectedId, ComboBox.ObjectCollection items)
    {
      return items.Cast<IEntity>()
        .FirstOrDefault(x => x.Id == selectedId);
    }

    private void FillDataTable()
    {
      var balance = this.userForm.myBalance(); ;

      dAdapter = new OleDbDataAdapter(balance, connection);
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
