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
      articleDataGridView.Columns["ArticleId"].Visible = false;
    }

    private void setCardService()
    {
      addCheckBoxInDataGrid("Select to delete", serviceDataGridView);
      string cardServiceQuery = cardService();
      setDataInTable(cardServiceQuery, "CardService", dsCardService, serviceDataGridView);
      addButtonInDataGrid(serviceDataGridView);
      serviceDataGridView.Columns["CardServiceId"].Visible = false;
    }

    private void setCurrency()
    {
      addCheckBoxInDataGrid("Select to delete", currencyDataGridView);
      string currencyQuery = currency();
      setDataInTable(currencyQuery, "Currency", dsCurrency, currencyDataGridView);
      addButtonInDataGrid(currencyDataGridView);
      currencyDataGridView.Columns["CurrencyId"].Visible = false;
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

    private void RefreshDataGrid(DataGridView dataGrid, DataSet ds)
    {
      dataGrid.Columns.Clear();
      ds = new DataSet();
    }

    private void deleteArticleButton_Click(object sender, EventArgs e)
    {
      List<int> articleIds = null;

      try
      {
        articleIds = (from DataGridViewRow r in articleDataGridView.Rows
                        where (string)r.Cells[0].Value == "1"
                        select (int)r.Cells["ArticleId"].Value).ToList();
      }
      catch
      {
        MessageBox.Show("Incorrect article!", "Article", MessageBoxButtons.OK);
        return;
      }

      var parametersPart = string.Join(",", articleIds.Select(x => "?"));
      var query = $"DELETE FROM Article WHERE ArticleId IN ({parametersPart})";

      using (var cmd = new OleDbCommand(query, connection))
      {
        for (var i = 0; i < articleIds.Count; i++)
          cmd.Parameters.Add(new OleDbParameter($"@ArticleId{i}", articleIds[i]));

        cmd.ExecuteNonQuery();
      }

      RefreshDataGrid(articleDataGridView, dsArticle);
      setArticle();
    }

    private void createArticleButton_Click(object sender, EventArgs e)
    {
      var name = nameArticleTextBox.Text;

      if (name == "")
      {
        MessageBox.Show("Empty fields!", "Article", MessageBoxButtons.OK);
        return;
      }

      string addArticleQuery =
        "INSERT INTO Article (Name) " +
        "VALUES(?)";

      OleDbCommand cmd = new OleDbCommand(addArticleQuery, connection);
      cmd.Parameters.Add(new OleDbParameter("@Name", name));

      try
      {
        cmd.ExecuteNonQuery();
        MessageBox.Show("Article added successfully!", "Article", MessageBoxButtons.OK);
        string articleQuery = article();
        refreshDataSet(articleQuery, dsArticle, "Article");
      }
      catch
      {
        MessageBox.Show("Incorrect parameters!", "Article", MessageBoxButtons.OK);
      }
    }

    private void createServiceButton_Click(object sender, EventArgs e)
    {
      var name = cardServiceTextBox.Text;
      var price = servicePriceNumericUpDown.Value.ToString();

      if (name == "" || price == "")
      {
        MessageBox.Show("Empty fields!", "Card Service", MessageBoxButtons.OK);
        return;
      }

      string addCardServiceQuery =
        "INSERT INTO CardService (Name, Price) " +
        "VALUES(?, ?)";

      OleDbCommand cmd = new OleDbCommand(addCardServiceQuery, connection);
      cmd.Parameters.Add(new OleDbParameter("@Name", name));
      cmd.Parameters.Add(new OleDbParameter("@Price", price));

      try
      {
        cmd.ExecuteNonQuery();
        MessageBox.Show("Card service added successfully!", "Card Service", MessageBoxButtons.OK);
        string cardServiceQuery = cardService();
        refreshDataSet(cardServiceQuery, dsCardService, "CardService");
      }
      catch
      {
        MessageBox.Show("Incorrect parameters!", "Card Service", MessageBoxButtons.OK);
      }
    }

    private void deleteCardServiceButton_Click(object sender, EventArgs e)
    {
      List<int> cardServiceIds = null;

      try
      {
        cardServiceIds = (from DataGridViewRow r in serviceDataGridView.Rows
                      where (string)r.Cells[0].Value == "1"
                      select (int)r.Cells["CardServiceId"].Value).ToList();
      }
      catch
      {
        MessageBox.Show("Incorrect card service!", "Card Service", MessageBoxButtons.OK);
        return;
      }

      var parametersPart = string.Join(",", cardServiceIds.Select(x => "?"));
      var query = $"DELETE FROM CardService WHERE CardServiceId IN ({parametersPart})";

      using (var cmd = new OleDbCommand(query, connection))
      {
        for (var i = 0; i < cardServiceIds.Count; i++)
          cmd.Parameters.Add(new OleDbParameter($"@CardServiceId{i}", cardServiceIds[i]));

        cmd.ExecuteNonQuery();
      }

      RefreshDataGrid(serviceDataGridView, dsCardService);
      setCardService();
    }

    private void createCurrencyButton_Click(object sender, EventArgs e)
    {
      var name = currencyNameTextBox.Text;

      if (name == "")
      {
        MessageBox.Show("Empty fields!", "Currency", MessageBoxButtons.OK);
        return;
      }

      string addCurrencyQuery =
        "INSERT INTO Currency (Name) " +
        "VALUES(?)";

      OleDbCommand cmd = new OleDbCommand(addCurrencyQuery, connection);
      cmd.Parameters.Add(new OleDbParameter("@Name", name));

      try
      {
        cmd.ExecuteNonQuery();
        MessageBox.Show("Currency added successfully!", "Currency", MessageBoxButtons.OK);
        string currencyQuery = currency();
        refreshDataSet(currencyQuery, dsCurrency, "Currency");
      }
      catch
      {
        MessageBox.Show("Incorrect parameters!", "Currency", MessageBoxButtons.OK);
      }
    }

    private void deleteCurrencyButton_Click(object sender, EventArgs e)
    {
      List<int> currencyIds = null;

      try
      {
        currencyIds = (from DataGridViewRow r in currencyDataGridView.Rows
                          where (string)r.Cells[0].Value == "1"
                          select (int)r.Cells["CurrencyId"].Value).ToList();
      }
      catch
      {
        MessageBox.Show("Incorrect currency!", "Currency", MessageBoxButtons.OK);
        return;
      }

      var parametersPart = string.Join(",", currencyIds.Select(x => "?"));
      var query = $"DELETE FROM Currency WHERE CurrencyId IN ({parametersPart})";

      using (var cmd = new OleDbCommand(query, connection))
      {
        for (var i = 0; i < currencyIds.Count; i++)
          cmd.Parameters.Add(new OleDbParameter($"@CurrencyId{i}", currencyIds[i]));

        cmd.ExecuteNonQuery();
      }

      RefreshDataGrid(currencyDataGridView, dsCurrency);
      setCurrency();
    }

    private void saveChangesButton_Click(object sender, EventArgs e)
    {
      var firstName = firstNameTextBox.Text;
      var lastName = lastNameTextBox.Text;
      var birthady = birthdayTimePicker.Value.Date.ToString("yyyy-MM-dd");
      var passNum = passportNumTextBox.Text;
      var phone = phoneTextBox.Text;

      var login = loginTextBox.Text;
      var password = passwordTextBox.Text;
      string role = "0";
      int userId = 0;


      if (firstName == "" || lastName == "" || birthady == "" || passNum == ""
          || phone == "" || login == "" || password == "")
      {
        MessageBox.Show("Empty fields!", "Customer", MessageBoxButtons.OK);
        return;
      }

      string addUserProfileQuery =
        "INSERT INTO User (Login, Password, Role) " +
        "VALUES(?, ?, ?)";

      OleDbCommand userProfileCmd = new OleDbCommand(addUserProfileQuery, connection);
      userProfileCmd.Parameters.Add(new OleDbParameter("@Login", login));
      userProfileCmd.Parameters.Add(new OleDbParameter("@Password", password));
      userProfileCmd.Parameters.Add(new OleDbParameter("@Role", role));

      try
      {
        OleDbDataReader rdr = userProfileCmd.ExecuteReader();
        rdr.Read();
        userId = Convert.ToInt32(rdr["Id"]);
      }
      catch (Exception ex)
      {
        MessageBox.Show("Incorrect parameters!", "Customer", MessageBoxButtons.OK);
      }

      string addCustomerQuery =
        "INSERT INTO Customer (FirstName, LastName, PassportNum, Birthday, Phone, UserId) " +
        "VALUES(?, ?, ?, ?, ?, ?)";

      OleDbCommand customerCmd = new OleDbCommand(addCustomerQuery, connection);
      customerCmd.Parameters.Add(new OleDbParameter("@FirstName", firstName));
      customerCmd.Parameters.Add(new OleDbParameter("@LastName", lastName));
      customerCmd.Parameters.Add(new OleDbParameter("@PassportNum", birthady));
      customerCmd.Parameters.Add(new OleDbParameter("@Birthday", passNum));
      customerCmd.Parameters.Add(new OleDbParameter("@Phone", phone));
      customerCmd.Parameters.Add(new OleDbParameter("@UserId", Convert.ToString(userId)));

      try
      {
        customerCmd.ExecuteNonQuery();
        MessageBox.Show("Customer added successfully!", "Customer", MessageBoxButtons.OK);
        string customerQuery = customer();
        refreshDataSet(customerQuery, dsAllCustomers, "Customer");
      }
      catch
      {
        MessageBox.Show("Incorrect parameters!", "Customer", MessageBoxButtons.OK);
      }
    }

    private void deleteCustomerButton_Click(object sender, EventArgs e)
    {

    }
  }
}
