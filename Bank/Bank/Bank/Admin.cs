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
  public partial class Admin : Form
  {
    public Admin()
    {
      InitializeComponent();
      connection.Open();
      setArticle();
      setCardService();
      setCurrency();
      setCustomer();
      setServiceComboBox();
    }

    private string article()
    {
      return
        "SELECT * FROM Article";
    }

    private string cardService()
    {
      return
        "SELECT * FROM CardService";
    }

    private string currency()
    {
      return
        "SELECT * FROM Currency";
    }

    private string customer()
    {
      return
        "SELECT * FROM Customer";
    }

    private void setArticle()
    {
      addCheckBoxInDataGrid("Select to delete", articleDataGridView);
      string articleQuery = article();
      setDataInTable(articleQuery, "Article", dsArticle, articleDataGridView);
      addButtonInDataGrid(articleDataGridView);
    }

    private void setCardService()
    {
      addCheckBoxInDataGrid("Select to delete", serviceDataGridView);
      string cardServiceQuery = cardService();
      setDataInTable(cardServiceQuery, "CardService", dsCardService, serviceDataGridView);
      addButtonInDataGrid(serviceDataGridView);
    }

    private void setCurrency()
    {
      addCheckBoxInDataGrid("Select to delete", currencyDataGridView);
      string currencyQuery = currency();
      setDataInTable(currencyQuery, "Currency", dsCurrency, currencyDataGridView);
      addButtonInDataGrid(currencyDataGridView);
    }

    private void setCustomer()
    {
      addCheckBoxInDataGrid("Select to delete", customerDataGridView);
      string customerQuery = customer();
      setDataInTable(customerQuery, "Customer", dsAllCustomers, customerDataGridView);
      addButtonInDataGrid(customerDataGridView);
    }

    private void addCheckBoxInDataGrid(string headerText, DataGridView dataGrid)
    {
      DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
      check.HeaderText = headerText;
      check.FalseValue = "0";
      check.TrueValue = "1";
      dataGrid.Columns.Insert(0, check);
    }

    private void addButtonInDataGrid(DataGridView dataGrid)
    {
      DataGridViewButtonColumn button = new DataGridViewButtonColumn();
      dataGrid.Columns.Add(button);
      button.HeaderText = "Click to edit";
      button.Text = "Edit";
      button.Name = "editButton";
      button.UseColumnTextForButtonValue = true;
    }

    private void setDataInTable(string query, string tableName, DataSet dataSet, DataGridView dataGrid)
    {
      var dataAdapter = new OleDbDataAdapter(query, connection);
      DataTable table = new DataTable(tableName);
      dataSet.Tables.Add(table);
      dataGrid.AutoGenerateColumns = true;
      dataGrid.DataSource = dataSet;
      dataGrid.DataMember = tableName;
      dataAdapter.Fill(dataSet, tableName);
    }

    private void setServiceComboBox()
    {
      OleDbCommand command = new OleDbCommand("SELECT [Name] FROM CardService", connection);
      OleDbDataReader rdr = command.ExecuteReader();
      while (rdr.Read())
        serviceStatisticComboBox.Items.Add(rdr["Name"]);
      rdr.Close();
    }

    private void parseComboBox(int index, string data, OleDbCommand cmdIC)
    {
      cmdIC.Parameters[index].Value = data.Remove(data.IndexOf("-") - 1,
        data.Length - data.IndexOf("-") + 1);
    }

    private void refreshDataSet(string query, DataSet ds, string table)
    {
      var command = new OleDbCommand(query, connection);
      var dataAdapter = new OleDbDataAdapter(command);
      ds.Clear();
      dataAdapter.Fill(ds, table);
    }

    private void Admin_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
      Application.Exit();
    }

    private void showServiceStatisticButton_Click(object sender, EventArgs e)
    {
      var service = serviceStatisticComboBox.Text;

      /*if (service == "")
      {
        MessageBox.Show("Empty test field!", "Credit types", MessageBoxButtons.OK);
        return;
      }

      string addCreditTypeQuery =
        "INSERT INTO InfoCredit([Name], CurrencyId, [Percent], Term) " +
        "VALUES(?, ?, ?, ?)";

      OleDbCommand cmdIC = new OleDbCommand(addCreditTypeQuery, connection);

      cmdIC.Parameters.Add(new OleDbParameter("@Name", info));
      cmdIC.Parameters.Add(new OleDbParameter("@CurrencyId", currency));
      cmdIC.Parameters.Add(new OleDbParameter("@Percent", percent));
      cmdIC.Parameters.Add(new OleDbParameter("@Term", term));

      parseComboBox(1, currency, cmdIC);

      try
      {
        cmdIC.ExecuteNonQuery();
        MessageBox.Show("Credit type added successfully!", "Credit type", MessageBoxButtons.OK);
        string creditTypesQuery = creditTypes();
        refreshDataSet(creditTypesQuery, dsCreditTypes, "InfoCredit");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Incorrect parameters!", "Credit types", MessageBoxButtons.OK);
      }*/
    }
  }
}
