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
      setUser();
      setInactiveCustomers();
      setRichestCustomers();
    }

    private string article()
    {
      return
        "SELECT [Name] FROM Article";
    }

    private string cardService()
    {
      return
        "SELECT [Name], Price FROM CardService";
    }

    private string currency()
    {
      return
        "SELECT [Name] FROM Currency";
    }

    private string customer()
    {
      return
        "SELECT " +
        "Customer.FirstName, " +
        "Customer.LastName, " +
        "Customer.PassportNum, " +
        "Customer.Birthday, " +
        "Customer.Phone, " +
        "[User].Login, " +
        "[User].Password " +
        "FROM Customer " +
        "JOIN [User] ON Customer.UserId = [User].Id";
    }

    private string user()
    {
      return
        "SELECT [Login], [Password], Role " +
        "FROM [User]";
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

    private void setUser()
    {
      addCheckBoxInDataGrid("Select to delete", usersDataGridView);
      string usersQuery = user();
      setDataInTable(usersQuery, "User", dsUser, usersDataGridView);
      addButtonInDataGrid(usersDataGridView);
    }

    private void setInactiveCustomers()
    {
      string inactiveCustomersQuery = "InactiveCustomers";
      setDataInTable(inactiveCustomersQuery, "CustomerStatistic", dsInactiveCustomers, inactiveCustomersDataGridView);
    }

    private void setRichestCustomers()
    {
      string richestCustomersQuery = "RichestCustomers";
      setDataInTable(richestCustomersQuery, "RichestCustomers", dsRichestCustomers, richestCustomersDataGridView);
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

      if (service == "")
      {
        MessageBox.Show("Empty text field!", "Call center", MessageBoxButtons.OK);
        return;
      }

      string getCustomersWithServiceQuery = "ServiceStatistic ?";

      OleDbCommand cmd = new OleDbCommand(getCustomersWithServiceQuery, connection);
      cmd.Parameters.Add(new OleDbParameter("@Name", service));

      try
      {
        cmd.ExecuteNonQuery();
        MessageBox.Show("Service statistic!", "Call center", MessageBoxButtons.OK);
        setDataInTable(getCustomersWithServiceQuery, "Service", dsServices, callCenterServiceDataGridView);
      }
      catch (Exception ex)
      {
        MessageBox.Show("Incorrect parameters!", "Call center", MessageBoxButtons.OK);
      }
    }
  }
}
