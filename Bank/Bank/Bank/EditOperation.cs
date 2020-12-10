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
  public partial class EditOperation : Form
  {
    private DataRow dRow;
    private DataTable dTable;
    private OleDbDataAdapter dAdapter;
    private readonly int operationId;
    private readonly int customerId;
    private readonly User userForm;

    public EditOperation(int operationId, int customerId, User userForm)
    {
      InitializeComponent();
      connection.Open();
      this.operationId = operationId;
      this.customerId = customerId;
      this.userForm = userForm;
      SetComboBox();
      SetData();
    }

    private void ShowRow()
    {
      dRow = dTable.Rows[0];

      articleComboBox.SelectedItem = GetSelectedItem((int)dRow["ArticleId"], articleComboBox.Items);
      balanceIdComboBox.SelectedItem = GetSelectedItem((int)dRow["BalanceId"], balanceIdComboBox.Items);
      currencyOperationComboBox.SelectedItem = GetSelectedItem((int)dRow["CurrencyId"], currencyOperationComboBox.Items);

      operationCashTextBox.Text = dRow["Cash"].ToString();
      dateOfOperationPicker.Text = dRow["Date"].ToString();
      whoseBalanceTextBox.Text = dRow["WhoseBalance"].ToString();
    }

    private object GetSelectedItem(int selectedId, ComboBox.ObjectCollection items)
    {
      return items.Cast<IEntity>()
        .FirstOrDefault(x => x.Id == selectedId);
    }

    private void FillDataTable()
    {
      var operation =
        "SELECT Article.ArticleId, " +
        "Balance.BalanceId, " +
        "Currency.CurrencyId, " +
        "Operation.Cash, " +
        "Operation.[Date], " +
        "Operation.WhoseBalance " +
        "FROM Operation " +
        "JOIN Article ON Operation.ArticleId = Article.ArticleId " +
        "JOIN Currency ON Operation.CurrencyId = Currency.CurrencyId " +
        "JOIN Balance ON Operation.BalanceId = Balance.BalanceId " +
        "WHERE Operation.OperationId = " + operationId;

      dAdapter = new OleDbDataAdapter(operation, connection);
      dTable = new DataTable();
      dAdapter.Fill(dTable);
    }

    private void SetData()
    {
      FillDataTable();
      ShowRow();
    }

    private void editOperationButton_Click(object sender, EventArgs e)
    {
      var articleId = ((Article)articleComboBox.SelectedItem).Id;
      var currencyId = ((Currency)currencyOperationComboBox.SelectedItem).Id;
      var balanceId = ((Balance)balanceIdComboBox.SelectedItem).Id;
      var cash = operationCashTextBox.Text;
      var date = dateOfOperationPicker.Value.Date.ToString("yyyy-MM-dd");
      var whoseBalance = whoseBalanceTextBox.Text;

      string updateOperationQuery =
        "UPDATE Operation " +
        "SET " +
          "ArticleId = ?, " +
          "CurrencyId = ?, " +
          "BalanceId = ?, " +
          "Cash = ?, " +
          "Date = ?, " +
          "WhoseBalance = ? " +
        "WHERE OperationId = ?";

      OleDbCommand cmd = new OleDbCommand(updateOperationQuery, connection);

      cmd.Parameters.Add(new OleDbParameter("@ArticleId", articleId));
      cmd.Parameters.Add(new OleDbParameter("@CurrencyId", currencyId));
      cmd.Parameters.Add(new OleDbParameter("@BalanceId", balanceId));
      cmd.Parameters.Add(new OleDbParameter("@Cash", cash));
      cmd.Parameters.Add(new OleDbParameter("@Date", date));
      cmd.Parameters.Add(new OleDbParameter("@WhoseBalance", whoseBalance));
      cmd.Parameters.Add(new OleDbParameter("@OperationId", operationId));

      cmd.ExecuteNonQuery();
      MessageBox.Show("Operation updated!", "Operation", MessageBoxButtons.OK);
    }

    private void SetComboBox()
    {
      using (var cmd = new OleDbCommand("SELECT ArticleId, [Name] FROM Article", connection))
      using (var reader = cmd.ExecuteReader())
      {
        while (reader.Read())
          articleComboBox.Items.Add(new Article(reader.GetInt32(0), reader.GetString(1)));
      }

      using (var cmd = new OleDbCommand("SELECT CurrencyId, [Name] FROM Currency", connection))
      using (var reader = cmd.ExecuteReader())
      {
        while (reader.Read())
          currencyOperationComboBox.Items.Add(new Currency(reader.GetInt32(0), reader.GetString(1)));
      }

      using (var cmd = new OleDbCommand("SELECT BalanceId, Number FROM Balance WHERE CustomerId = ?", connection))
      {
        cmd.Parameters.Add(new OleDbParameter("@CustomerId", customerId));

        using (var reader = cmd.ExecuteReader())
        {
          while (reader.Read())
            balanceIdComboBox.Items.Add(new Balance(reader.GetInt32(0), reader.GetInt32(1)));
        }
      }
    }

    private void refreshDataSet(string query, DataSet ds, string table)
    {
      var command = new OleDbCommand(query, connection);
      var dataAdapter = new OleDbDataAdapter(command);
      dataAdapter.Fill(ds.Tables[0]);
    }

    private void EditOperation_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
      this.userForm.RefreshOperationDataGrid();
    }
  }
}
