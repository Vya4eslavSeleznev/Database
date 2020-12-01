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
  public partial class User : Form
  {
    private int customerId;
    private System.Data.DataRow dRow;
    private System.Data.DataTable dTable;
    private int iRowID;
    private System.Data.OleDb.OleDbDataAdapter dAdapter;

    public User(int customerId)
    {
      iRowID = 0;
      this.customerId = customerId;
      InitializeComponent();
      connection.Open();
      setOperation();
      setBalance();
      setMyCards();
      setCardServices();
      setMyCredit();
      setCreditInformation();
      setMyDeposit();
      setDepositInfo();
      setPopularDeposits();
      setMySecurities();
      setSecurityInfo();
      setPopularSecurities();
      setProfile();

      birthdayTimePicker.Value.ToShortDateString();
    }

    private void ShowRow()
    {
      dRow = dTable.Rows[iRowID];

      firstNameTextBox.Text = dRow["FirstName"].ToString();
      lastNameTextBox.Text = dRow["LastName"].ToString();
      birthdayTimePicker.Text = dRow["Birthday"].ToString();
      passportNumTextBox.Text = dRow["PassportNum"].ToString();
      phoneTextBox.Text = dRow["Phone"].ToString();
      loginTextBox.Text = dRow["Login"].ToString();
      passwordTextBox.Text = dRow["Login"].ToString();
    }

    private void FillDataTable()
    {
      var profile =
        "SELECT FirstName, LastName, Birthday, PassportNum, Phone, [Login], [Password] " +
        "FROM Customer " +
        "JOIN[User] ON Customer.UserId = [User].Id";

      dAdapter = new OleDbDataAdapter(profile, connection);
      dAdapter.Fill(dsCustomer, "Customer");
      dTable = dsCustomer.Tables["Customer"];
    }

    private void setProfile()
    {
      FillDataTable();
      ShowRow();
    }

    private void operationDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      var senderGrid = (DataGridView)sender;

      if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
      {
        //TEST
        MessageBox.Show("Incorrect type of account!" + e.RowIndex, "Authentication", MessageBoxButtons.OK);
      }
    }

    private void setOperation()
    {
      string myOperationQuery =
        "SELECT Article.[Name] AS Article, Currency.[Name] AS Currency, Balance.Number, " +
        "Operation.Cash, Operation.[Date], Operation.WhoseBalance " +
        "FROM Operation " +
        "JOIN Article " +
        "ON Operation.ArticleId = Article.ArticleId " +
        "JOIN Currency " +
        "ON Operation.CurrencyId = Currency.CurrencyId " +
        "JOIN Balance " +
        "ON Operation.BalanceId = Balance.BalanceId " +
        "WHERE CustomerId = " + customerId;

      addCheckBoxInDataGrid("Select to delete", operationDataGridView);
      setDataInTable(myOperationQuery, "Operation", dsOperation, operationDataGridView);
      addButtonInDataGrid(operationDataGridView);
    }

    private void setBalance()
    {
      string myBalanceQuery =
        "SELECT Balance.Number, Balance.[Date], Currency.[Name], " +
        "Balance.Debit, Balance.Credit, Balance.CardId " +
        "FROM Balance " +
        "JOIN Currency ON Balance.CurrencyId = Currency.CurrencyId " +
        "WHERE CustomerId = " + customerId;

      addCheckBoxInDataGrid("Select to delete", balancesDataGridView);
      setDataInTable(myBalanceQuery, "Balance", dsBalance, balancesDataGridView);
      addButtonInDataGrid(balancesDataGridView);
    }

    private void setMyCards()
    {
      string myCardsQuery =
        "SELECT [Card].Number, CardService.[Name] AS Service " +
        "FROM[Card] " +
        "JOIN CardService ON[Card].CardServiceId = CardService.CardServiceId " +
        "JOIN BalanceCards ON[Card].CardId = BalanceCards.BalanceId " +
        "JOIN Balance ON BalanceCards.BalanceId = Balance.BalanceId " +
        "WHERE Balance.CustomerId = " + customerId;

      addCheckBoxInDataGrid("Select to delete", cardsDataGridView);
      setDataInTable(myCardsQuery, "Card", dsCard, cardsDataGridView);
      addButtonInDataGrid(cardsDataGridView);
    }

    private void setCardServices()
    {
      string cardServiceQuery =
        "SELECT [Name], Price " +
        "FROM CardService";

      setDataInTable(cardServiceQuery, "CardService", dsCardService, servicesDataGridView);
    }

    private void setMyCredit()
    {
      string myCreditQuery =
        "SELECT CustomerCredit.Info, CustomerCredit.Amount, Currency.[Name] AS Currency, " +
        "InfoCredit.Term, InfoCredit.[Percent] " +
        "FROM CustomerCredit " +
        "JOIN InfoCredit ON CustomerCredit.InfoCreditId = InfoCredit.InfoCreditId " +
        "JOIN Currency ON InfoCredit.CurrencyId = Currency.CurrencyId " +
        "WHERE CustomerId = " + customerId;

      setDataInTable(myCreditQuery, "CustomerCredit", dsCredit, myCreditDataGridView);
    }

    private void setCreditInformation()
    {
      string creditInfoQuery =
        "SELECT InfoCredit.[Name] AS NameOfCredit, Currency.[Name] AS Currency, " +
        "InfoCredit.[Percent], InfoCredit.Term, InfoCredit.Date " +
        "FROM InfoCredit " +
        "JOIN Currency ON InfoCredit.CurrencyId = Currency.CurrencyId";

      setDataInTable(creditInfoQuery, "InfoCredit", dsCreditInfo, creditInfoDataGridView);
    }

    private void setMyDeposit()
    {
      string myDepositQuery =
        "SELECT InfoDeposit.DepositName, CustomerDeposit.Amount " +
        "FROM CustomerDeposit " +
        "JOIN InfoDeposit ON CustomerDeposit.InfoDepositId = InfoDeposit.InfoDepositId " +
        "WHERE CustomerId = " + customerId;

      addCheckBoxInDataGrid("Select to terminate", myDepositsDataGridView);
      setDataInTable(myDepositQuery, "CustomerDeposit", dsMyDeposit, myDepositsDataGridView);
    }

    private void setDepositInfo()
    {
      string depositInfoQuery =
        "SELECT InfoDeposit.Term, InfoDeposit.Amount, Currency.[Name] AS Currency, " +
        "InfoDeposit.[Percent], InfoDeposit.DepositName " +
        "FROM InfoDeposit " +
        "JOIN Currency ON InfoDeposit.CurrencyId = Currency.CurrencyId";

      setDataInTable(depositInfoQuery, "InfoDeposit", dsDepositInfo, depositInfoDataGridView);
    }

    private void setPopularDeposits()
    {
      string popularDepositsQuery =
        "SELECT TOP(10) " +
        "InfoDeposit.DepositName, " +
        "COUNT(*) AS DepositCount " +
        "FROM InfoDeposit " +
        "JOIN CustomerDeposit ON InfoDeposit.InfoDepositId = CustomerDeposit.InfoDepositId " +
        "GROUP BY InfoDeposit.DepositName " +
        "HAVING COUNT(*) > 10 " +
        "ORDER BY COUNT(*)";

      setDataInTable(popularDepositsQuery, "InfoDeposit", dsTopDeposits, topDepositsDataGridView);
    }

    private void setMySecurities()
    {
      string mySecuritiesQuery =
        "SELECT InfoSecurities.[Name], CustomerSecurities.Count " +
        "FROM CustomerSecurities " +
        "JOIN InfoSecurities ON CustomerSecurities.InfoSecuritiesId = InfoSecurities.InfoSecuritiesId " +
        "WHERE CustomerId = " + customerId;

      addCheckBoxInDataGrid("Select to sell", mySecuritiesDataGridView);
      setDataInTable(mySecuritiesQuery, "CustomerSecurities", dsMySecurities, mySecuritiesDataGridView);
    }

    private void setSecurityInfo()
    {
      string securityInfoQuery =
        "SELECT InfoSecurities.[Name], InfoSecurities.Price, Currency.[Name] AS Currency, " +
        "InfoSecurities.[Percent rate] " +
        "FROM InfoSecurities " +
        "JOIN Currency ON InfoSecurities.CurrencyId = Currency.CurrencyId";

      setDataInTable(securityInfoQuery, "InfoSecurities", dsSecurityInfo, securityInfoDataGridView);
    }

    private void setPopularSecurities()
    {
      string topSecuritysQuery =
        "SELECT Name, SUM(CustomerSecurities.Count), [Percent rate] " +
        "FROM CustomerSecurities " +
        "JOIN InfoSecurities ON CustomerSecurities.InfoSecuritiesId = InfoSecurities.InfoSecuritiesId " +
        "GROUP BY Name, [Percent rate] " +
        "ORDER BY COUNT(*) DESC";

      setDataInTable(topSecuritysQuery, "InfoSecurities", dsTopSecurities, topSecuritiesDataGridView);
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

    private void User_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
      Application.Exit();
    }

    private void saveChangesButton_Click(object sender, EventArgs e)
    {
      var firstName = firstNameTextBox.Text;
      var lastName = lastNameTextBox.Text;
      var birthday = birthdayTimePicker.Value.Date.ToString("yyyy / MM / dd");
      var passNum = passportNumTextBox.Text;
      var phone = phoneTextBox.Text;

      string updateProfileQuery =
        "UPDATE Customer " +
        "SET " +
          "FirstName = ?, " +
          "LastName = ?, " +
          "Birthday = ?, " +
          "PassportNum = ?, " +
          "Phone = ? " +
        " WHERE CustomerId = ?";

      OleDbCommand cmdIC = new OleDbCommand(updateProfileQuery, connection);

      cmdIC.Parameters.Add(new OleDbParameter("@FirstName", firstName));
      cmdIC.Parameters.Add(new OleDbParameter("@LastName", lastName));
      cmdIC.Parameters.Add(new OleDbParameter("@Birthday", birthday));
      cmdIC.Parameters.Add(new OleDbParameter("@PassportNum", passNum));
      cmdIC.Parameters.Add(new OleDbParameter("@Phone", phone));
      cmdIC.Parameters.Add(new OleDbParameter("@CustomerId", customerId));

      cmdIC.ExecuteNonQuery();
      MessageBox.Show("Personal information updated!", "Profile", MessageBoxButtons.OK);
    }

    private void changeLoginAndPasswordButton_Click(object sender, EventArgs e)
    {
      var login = loginTextBox.Text;
      var password = passwordTextBox.Text;

      string updateProfileQuery =
        "UPDATE [User] " +
        "SET " +
          "[Login] = ?, " +
          "[Password] = ?, " +
        " WHERE CustomerId = ?";

      OleDbCommand cmdIC = new OleDbCommand(updateProfileQuery, connection);

      cmdIC.Parameters.Add(new OleDbParameter("@Login", login));
      cmdIC.Parameters.Add(new OleDbParameter("@Password", password));
      cmdIC.Parameters.Add(new OleDbParameter("@CustomerId", customerId));

      cmdIC.ExecuteNonQuery();
      MessageBox.Show("Login and password updated!", "Profile", MessageBoxButtons.OK);
    }
  }
}
