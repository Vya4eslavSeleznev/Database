﻿using System;
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
      setComboBox();

      birthdayTimePicker.Value.ToShortDateString();
    }

    private void setCurrencyComboBox(OleDbCommand command, OleDbDataReader rdr, ComboBox comboBox)
    {
      command.CommandText = "SELECT CurrencyId, [Name] FROM Currency";
      rdr = command.ExecuteReader();
      while (rdr.Read())
        comboBox.Items.Add(rdr["CurrencyId"] + " - " + rdr["Name"]);
      rdr.Close();
    }

    private void setComboBox()
    {
      OleDbCommand command = new OleDbCommand("SELECT ArticleId, [Name] FROM Article", connection);
      OleDbDataReader rdr = command.ExecuteReader();
      while (rdr.Read())
        articleComboBox.Items.Add(rdr["ArticleId"] + " - " + rdr["Name"]);
      rdr.Close();

      command.CommandText = "SELECT CurrencyId, [Name] FROM Currency";
      rdr = command.ExecuteReader();
      while (rdr.Read())
        currencyOperationComboBox.Items.Add(rdr["CurrencyId"] + " - " + rdr["Name"]);
      rdr.Close();

      command.CommandText = "SELECT BalanceId, Number FROM Balance WHERE CustomerId = ?";
      command.Parameters.Add(new OleDbParameter("@CustomerId", customerId));
      rdr = command.ExecuteReader();
      while (rdr.Read())
        balanceIdComboBox.Items.Add(rdr["BalanceId"] + " - " + rdr["Number"]);
      rdr.Close();

      /*command.CommandText = "SELECT CardServiceId, [Name] FROM CardService";
      rdr = command.ExecuteReader();
      while (rdr.Read())
        cardServiceComboBox.Items.Add(rdr["CardServiceId"] + " - " + rdr["Name"]);
      rdr.Close();*/

      setCurrencyComboBox(command, rdr, currencyBalanceComboBox);
      setCurrencyComboBox(command, rdr, currencyStatisticComboBox);

      /*command.CommandText = 
        "SELECT [Card].Number, " +
        "FROM [Card] " +
        "JOIN BalanceCards ON [Card].CardId = BalanceCards.BalanceId " +
        "JOIN Balance ON BalanceCards.BalanceId = Balance.BalanceId " +
        "WHERE Balance.CustomerId = ?";
      //command.Parameters.Add("@CustomerId", OleDbType.Integer);
      //command.Parameters[0].Value = customerId;
      command.Parameters.Add(new OleDbParameter("@CustomerId", customerId));
      //rdr = command.ExecuteReader();
      rdr = command.ExecuteReader();
      while (rdr.Read())
        cardComboBox.Items.Add(rdr["Number"]);
      rdr.Close();*/

      command.CommandText = "SELECT InfoCreditId, [Name] FROM InfoCredit";
      rdr = command.ExecuteReader();
      while (rdr.Read())
        typeCreditComboBox.Items.Add(rdr["InfoCreditId"] + " - " + rdr["Name"]);
      rdr.Close();

      command.CommandText = "SELECT InfoDepositId, DepositName FROM InfoDeposit";
      rdr = command.ExecuteReader();
      while (rdr.Read())
        depositTypeComboBox.Items.Add(rdr["InfoDepositId"] + " - " + rdr["DepositName"]);
      rdr.Close();

      command.CommandText = "SELECT InfoSecuritiesId, [Name] FROM InfoSecurities";
      rdr = command.ExecuteReader();
      while (rdr.Read())
        securityTypeComboBox.Items.Add(rdr["InfoSecuritiesId"] + " - " + rdr["Name"]);
      rdr.Close();
    }

    private void ShowRow()
    {
      dRow = dTable.Rows[iRowID];
      //dRow = dTable.Rows[customerId];

      firstNameTextBox.Text = dRow["FirstName"].ToString();
      lastNameTextBox.Text = dRow["LastName"].ToString();
      birthdayTimePicker.Text = dRow["Birthday"].ToString();
      passportNumTextBox.Text = dRow["PassportNum"].ToString();
      phoneTextBox.Text = dRow["Phone"].ToString();
      loginTextBox.Text = dRow["Login"].ToString();
      passwordTextBox.Text = dRow["Password"].ToString();
    }

    private void FillDataTable()
    {
      var profile =
        "SELECT FirstName, LastName, Birthday, PassportNum, Phone, [Login], [Password] " +
        "FROM Customer " +
        "JOIN [User] ON Customer.UserId = [User].Id";

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
        try
        {
          var operationId = (int)operationDataGridView["OperationId", e.RowIndex].Value;

          //MessageBox.Show("Incorrect type of account!" + e.RowIndex, "Authentication", MessageBoxButtons.OK);
          string operation = myOperation();
          var editOperation = new EditOperation(dsOperation, operationId, customerId, operation, operationDataGridView);
          editOperation.Show();
          //refreshDataSet(operation, dsOperation, "Operation");
        }
        catch
        {
          MessageBox.Show("Incorrect parameters!", "Operation", MessageBoxButtons.OK);
        }
      }
    }

    private string myOperation()
    {
      return
        "SELECT Operation.OperationId, " +
        "Article.[Name] AS Article, " +
        "Currency.[Name] AS Currency, " +
        "Balance.Number, " +
        "Balance.BalanceId, " +
        "Operation.Cash, Operation.[Date], Operation.WhoseBalance " +
        "FROM Operation " +
        "JOIN Article " +
        "ON Operation.ArticleId = Article.ArticleId " +
        "JOIN Currency " +
        "ON Operation.CurrencyId = Currency.CurrencyId " +
        "JOIN Balance " +
        "ON Operation.BalanceId = Balance.BalanceId " +
        "WHERE CustomerId = " + customerId;
    }

    private string myCard()
    {
      return
        "SELECT [Card].Number, CardService.[Name] AS Service " +
        "FROM [Card] " +
        "JOIN CardServices ON [Card].CardId = CardServices.CardId " +
        "JOIN CardService ON CardServices.ServiceId = CardService.CardServiceId " +
        "JOIN BalanceCards ON [Card].CardId = BalanceCards.BalanceId " +
        "JOIN Balance ON BalanceCards.BalanceId = Balance.BalanceId " +
        "WHERE Balance.CustomerId = " + customerId;
    }

    private string myCredit()
    {
      return
        "SELECT CustomerCredit.Info, CustomerCredit.Amount, Currency.[Name] AS Currency, " +
        "InfoCredit.Term, InfoCredit.[Percent] " +
        "FROM CustomerCredit " +
        "JOIN InfoCredit ON CustomerCredit.InfoCreditId = InfoCredit.InfoCreditId " +
        "JOIN Currency ON InfoCredit.CurrencyId = Currency.CurrencyId " +
        "WHERE CustomerId = " + customerId;
    }

    private string myDeposit()
    {
      return
        "SELECT InfoDeposit.DepositName, CustomerDeposit.Amount " +
        "FROM CustomerDeposit " +
        "JOIN InfoDeposit ON CustomerDeposit.InfoDepositId = InfoDeposit.InfoDepositId " +
        "WHERE CustomerId = " + customerId;
    }

    private string mySecurities()
    {
      return
        "SELECT InfoSecurities.[Name], CustomerSecurities.Count " +
        "FROM CustomerSecurities " +
        "JOIN InfoSecurities ON CustomerSecurities.InfoSecuritiesId = InfoSecurities.InfoSecuritiesId " +
        "WHERE CustomerId = " + customerId;
    }

    private string popularSecurities()
    {
      return
        "SELECT Name, SUM(CustomerSecurities.Count), [Percent rate] " +
        "FROM CustomerSecurities " +
        "JOIN InfoSecurities ON CustomerSecurities.InfoSecuritiesId = InfoSecurities.InfoSecuritiesId " +
        "GROUP BY Name, [Percent rate] " +
        "ORDER BY SUM(CustomerSecurities.Count) DESC";
    }

    private string popularDeposits()
    {
      return
        "SELECT TOP(10) " +
        "InfoDeposit.DepositName, " +
        "COUNT(*) AS DepositCount " +
        "FROM InfoDeposit " +
        "JOIN CustomerDeposit ON InfoDeposit.InfoDepositId = CustomerDeposit.InfoDepositId " +
        "GROUP BY InfoDeposit.DepositName " +
        "HAVING COUNT(*) > 10 " +
        "ORDER BY COUNT(*)";
    }

    private void setOperation()
    {
      string myOperationQuery = myOperation();

      addCheckBoxInDataGrid("Select to delete", operationDataGridView);
      setDataInTable(myOperationQuery, "Operation", dsOperation, operationDataGridView);
      addButtonInDataGrid(operationDataGridView, "Click to edit", "Edit");
    }

    private void setBalance()
    {
      string myBalanceQuery =
        "SELECT Balance.Number, Balance.[Date], Currency.[Name], " +
        "Balance.Cash " +
        "FROM Balance " +
        "JOIN Currency ON Balance.CurrencyId = Currency.CurrencyId " +
        "WHERE CustomerId = " + customerId;

      addCheckBoxInDataGrid("Select to delete", balancesDataGridView);
      setDataInTable(myBalanceQuery, "Balance", dsBalance, balancesDataGridView);
      addButtonInDataGrid(balancesDataGridView, "Click to edit", "Edit");
      addButtonInDataGrid(balancesDataGridView, "Click to add card", "Add card");
    }

    private void setMyCards()
    {
      string myCardsQuery = myCard();

      addCheckBoxInDataGrid("Select to delete", cardsDataGridView);
      setDataInTable(myCardsQuery, "Card", dsCard, cardsDataGridView);
      addButtonInDataGrid(cardsDataGridView, "Click to edit", "Edit");
      addButtonInDataGrid(cardsDataGridView, "Click to add service", "Add service");
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
      string myCreditQuery = myCredit();
      setDataInTable(myCreditQuery, "CustomerCredit", dsCredit, myCreditDataGridView);
    }

    private void setCreditInformation()
    {
      string creditInfoQuery =
        "SELECT InfoCredit.[Name] AS NameOfCredit, Currency.[Name] AS Currency, " +
        "InfoCredit.[Percent], InfoCredit.Term " +
        "FROM InfoCredit " +
        "JOIN Currency ON InfoCredit.CurrencyId = Currency.CurrencyId";

      setDataInTable(creditInfoQuery, "InfoCredit", dsCreditInfo, creditInfoDataGridView);
    }

    private void setMyDeposit()
    {
      string myDepositQuery = myDeposit();

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
      string popularDepositsQuery = popularDeposits();
      setDataInTable(popularDepositsQuery, "InfoDeposit", dsTopDeposits, topDepositsDataGridView);
    }

    private void setMySecurities()
    {
      string mySecuritiesQuery = mySecurities();

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
      string topSecuritysQuery = popularSecurities();
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

    private void addButtonInDataGrid(DataGridView dataGrid, string headerText, string textButton)
    {
      DataGridViewButtonColumn button = new DataGridViewButtonColumn();
      dataGrid.Columns.Add(button);
      button.HeaderText = headerText;//"Click to edit";
      button.Text = textButton;// "Edit";
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

    private void setDataInTable(OleDbCommand command, DataSet dataSet, DataGridView dataGrid)
    {
      var dataAdapter = new OleDbDataAdapter(command);
      var dataTable = new DataTable();
      dataAdapter.Fill(dataTable);
      dataGrid.DataSource = dataTable;
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

      if (firstName == "" || lastName == "" || birthday == ""
          || passNum == "" || phone == "")
      {
        MessageBox.Show("Empty test field!", "Profile", MessageBoxButtons.OK);
        return;
      }

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

      try
      {
        cmdIC.ExecuteNonQuery();
        MessageBox.Show("Personal information updated!", "Profile", MessageBoxButtons.OK);
      }
      catch
      {
        MessageBox.Show("Incorrect personal information!", "Profile", MessageBoxButtons.OK);
      }
    }

    private void changeLoginAndPasswordButton_Click(object sender, EventArgs e)
    {
      var login = loginTextBox.Text;
      var password = passwordTextBox.Text;

      if (login == "" || password == "")
      {
        MessageBox.Show("Empty test field!", "Profile", MessageBoxButtons.OK);
        return;
      }

      string updateProfileQuery =
        "UPDATE[User] " +
          "SET[Login] = ?, " +
          "[Password] = ? " +
          "FROM [User] " +
          "JOIN Customer ON [User].Id = Customer.UserId " +
        "WHERE CustomerId = ?";

      OleDbCommand cmdIC = new OleDbCommand(updateProfileQuery, connection);

      cmdIC.Parameters.Add(new OleDbParameter("@Login", login));
      cmdIC.Parameters.Add(new OleDbParameter("@Password", password));
      cmdIC.Parameters.Add(new OleDbParameter("@CustomerId", customerId));

      try
      {
        cmdIC.ExecuteNonQuery();
        MessageBox.Show("Login and password updated!", "Profile", MessageBoxButtons.OK);
      }
      catch
      {
        MessageBox.Show("Incorrect login or password!", "Profile", MessageBoxButtons.OK);
      }
    }

    private void parseComboBox(int index, string data, OleDbCommand cmdIC)
    {
      cmdIC.Parameters[index].Value = data.Remove(data.IndexOf("-") - 1,
        data.Length - data.IndexOf("-") + 1);
    }

    private void addOperationButton_Click(object sender, EventArgs e)
    {
      var articleId = articleComboBox.Text;
      var currencyId = currencyOperationComboBox.Text;
      var balanceId = balanceIdComboBox.Text;
      var cash = operationCashTextBox.Text;
      var date = dateOfOperationPicker.Value.Date.ToString("yyyy / MM / dd");
      var whoseBalance = whoseBalanceTextBox.Text;

      if (articleId == "" || currencyId == "" || balanceId == ""
         || cash == "" || date == "" || whoseBalance == "")
      {
        MessageBox.Show("Incorrect parameters!", "Operation", MessageBoxButtons.OK);
        return;
      }

      string addOperationQuery =
        "INSERT INTO Operation (ArticleId, CurrencyId, BalanceId, Cash, [Date], WhoseBalance) " +
        "VALUES(?, ?, ?, ?, ?, ?)";

      OleDbCommand cmdIC = new OleDbCommand(addOperationQuery, connection);

      cmdIC.Parameters.Add(new OleDbParameter("@ArticleId", articleId));
      cmdIC.Parameters.Add(new OleDbParameter("@CurrencyId", currencyId));
      cmdIC.Parameters.Add(new OleDbParameter("@BalanceId", balanceId));
      cmdIC.Parameters.Add(new OleDbParameter("@Cash", cash));
      cmdIC.Parameters.Add(new OleDbParameter("@Date", date));
      cmdIC.Parameters.Add(new OleDbParameter("@BalanWhoseBalanceceId", whoseBalance));

      parseComboBox(0, articleId, cmdIC);
      parseComboBox(1, currencyId, cmdIC);
      parseComboBox(2, balanceId, cmdIC);

      try
      {
        cmdIC.ExecuteNonQuery();
        MessageBox.Show("Operation added successfully!", "Operation", MessageBoxButtons.OK);
        string myOperationQuery = myOperation();
        refreshDataSet(myOperationQuery, dsOperation, "Operation");
      }
      catch
      {
        MessageBox.Show("Incorrect parameters!", "Operation", MessageBoxButtons.OK);
      }
    }

    private void addCardButton_Click(object sender, EventArgs e)
    {
      var number = cardNumberTextBox.Text;

      if (number == "")
      {
        MessageBox.Show("Empty test field!", "Card", MessageBoxButtons.OK);
        return;
      }

      string addCardQuery =
        "INSERT INTO Card (Number) " +
        "VALUES(?)";

      OleDbCommand cmdIC = new OleDbCommand(addCardQuery, connection);
      cmdIC.Parameters.Add(new OleDbParameter("@Number", number));

      try
      {
        cmdIC.ExecuteNonQuery();
        MessageBox.Show("Card added successfully!", "Card", MessageBoxButtons.OK);
        string myCardsQuery = myCard();
        refreshDataSet(myCardsQuery, dsCard, "Card");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Incorrect parameters!", "Card", MessageBoxButtons.OK);
      }
    }

    private void refreshDataSet(string query, DataSet ds, string table)
    {
      var command = new OleDbCommand(query, connection);
      var dataAdapter = new OleDbDataAdapter(command);
      ds.Clear();
      dataAdapter.Fill(ds, table);
    }

    private void showButton_Click(object sender, EventArgs e)
    {
      var dateFrom = dateFromTimePicker.Value.Date.ToString("yyyy-MM-dd");
      var dateTo = dateToPicker.Value.Date.ToString("yyyy-MM-dd");
      var currency = currencyStatisticComboBox.Text;

      if (dateFrom == "" || dateTo == "" || currency == "")
      {
        MessageBox.Show("Empty test field!", "Statistic", MessageBoxButtons.OK);
        return;
      }

      string showStatisticQuery = "OperationStatistic ?, ?, ?, ?";

      OleDbCommand cmdIC = new OleDbCommand(showStatisticQuery, connection);

      var currencyId = int.Parse(currency.Split('-')[0].Trim());

      var startDateParamter = new OleDbParameter("@StartDate", OleDbType.Date);
      var endDateParameter = new OleDbParameter("@EndDate", OleDbType.Date);

      startDateParamter.Value = dateFrom;
      endDateParameter.Value = dateTo;

      cmdIC.Parameters.Add(new OleDbParameter("@CustomerId", customerId));
      cmdIC.Parameters.Add(new OleDbParameter("@CurrencyId", currencyId));
      cmdIC.Parameters.Add(startDateParamter);
      cmdIC.Parameters.Add(endDateParameter);

      try
      {
        setDataInTable(cmdIC, dsOperationStatistic, statisticDataGridView);
        MessageBox.Show("Operation Statistic!", "Statistic", MessageBoxButtons.OK);
      }
      catch
      {
        MessageBox.Show("Incorrect parameters!", "Statistic", MessageBoxButtons.OK);
      }
    }

    private void addCreditButton_Click(object sender, EventArgs e)
    {
      var typeOfCredit = typeCreditComboBox.Text;
      var amount = amountCreditTextBox.Text;
      var forWhat = forWhatCreditTextBox.Text;

      if (typeOfCredit == "" || amount == "" || forWhat == "")
      {
        MessageBox.Show("Empty test field!", "Credit", MessageBoxButtons.OK);
        return;
      }

      string addCreditQuery = 
        "INSERT INTO CustomerCredit(InfoCreditId, CustomerId, Info, Amount) " +
        "VALUES(?, ?, ?, ?)";

      OleDbCommand cmdIC = new OleDbCommand(addCreditQuery, connection);

      cmdIC.Parameters.Add(new OleDbParameter("@InfoCreditId", typeOfCredit));
      cmdIC.Parameters.Add(new OleDbParameter("@CustomerId", customerId));
      cmdIC.Parameters.Add(new OleDbParameter("@Info", forWhat));
      cmdIC.Parameters.Add(new OleDbParameter("@Amount", amount));

      parseComboBox(0, typeOfCredit, cmdIC);

      try
      {
        cmdIC.ExecuteNonQuery();
        MessageBox.Show("Credit added successfully!", "Credit", MessageBoxButtons.OK);
        string myCreditQuery = myCredit();
        refreshDataSet(myCreditQuery, dsCredit, "CustomerCredit");
      }
      catch
      {
        MessageBox.Show("Incorrect parameters!", "Credit", MessageBoxButtons.OK);
      }
    }

    private void addDepositButton_Click(object sender, EventArgs e)
    {
      var depositType = depositTypeComboBox.Text;
      var amount = depositAmountTextBox.Text;

      if (depositType == "" || amount == "")
      {
        MessageBox.Show("Empty test field!", "Deposit", MessageBoxButtons.OK);
        return;
      }

      string addDepositQuery =
        "INSERT INTO CustomerDeposit(CustomerId, InfoDepositId, Amount) " +
        "VALUES(?, ?, ?)";

      OleDbCommand cmdIC = new OleDbCommand(addDepositQuery, connection);

      cmdIC.Parameters.Add(new OleDbParameter("@CustomerId", customerId));
      cmdIC.Parameters.Add(new OleDbParameter("@InfoDepositId", depositType));
      cmdIC.Parameters.Add(new OleDbParameter("@Amount", amount));

      parseComboBox(1, depositType, cmdIC);

      try
      {
        cmdIC.ExecuteNonQuery();
        MessageBox.Show("Deposit added successfully!", "Deposit", MessageBoxButtons.OK);
        string myDepositQuery = myDeposit();
        string popularDepositsQuery = popularDeposits();
        refreshDataSet(myDepositQuery, dsMyDeposit, "CustomerDeposit");
        refreshDataSet(popularDepositsQuery, dsTopDeposits, "InfoDeposit");
      }
      catch
      {
        MessageBox.Show("Incorrect parameters!", "Deposit", MessageBoxButtons.OK);
      }
    }

    private void buySecurityButton_Click(object sender, EventArgs e)
    {
      var securityType = securityTypeComboBox.Text;
      var count = securitiesCountTextBox.Text;

      if (securityType == "" || count == "")
      {
        MessageBox.Show("Empty test field!", "Security", MessageBoxButtons.OK);
        return;
      }

      string addDepositQuery =
        "INSERT INTO CustomerSecurities(InfoSecuritiesId, CustomerId, Count) " +
        "VALUES(?, ?, ?)";

      OleDbCommand cmdIC = new OleDbCommand(addDepositQuery, connection);

      cmdIC.Parameters.Add(new OleDbParameter("@InfoSecuritiesId", securityType));
      cmdIC.Parameters.Add(new OleDbParameter("@CustomerId", customerId));
      cmdIC.Parameters.Add(new OleDbParameter("@Count", count));

      parseComboBox(0, securityType, cmdIC);

      try
      {
        cmdIC.ExecuteNonQuery();
        MessageBox.Show("Deposit added successfully!", "Deposit", MessageBoxButtons.OK);
        string mySecuritiesQuery = mySecurities();
        string topSecuritysQuery = popularSecurities();
        refreshDataSet(mySecuritiesQuery, dsMySecurities, "CustomerSecurities");
        refreshDataSet(topSecuritysQuery, dsTopSecurities, "InfoSecurities");
      }
      catch
      {
        MessageBox.Show("Incorrect parameters!", "Securities", MessageBoxButtons.OK);
      }
    }

    private void cardsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      var senderGrid = (DataGridView)sender;

      if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
      {
        try
        {
          var editCard = new EditCard(customerId);
          editCard.Show();
        }
        catch
        {
          MessageBox.Show("Incorrect parameters!", "Card", MessageBoxButtons.OK);
        }
      }
    }

    private void balancesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      var senderGrid = (DataGridView)sender;

      if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
      {
        try
        {
          var editBalance = new EditBalance(customerId);
          editBalance.Show();
        }
        catch (Exception ex)
        {
          MessageBox.Show("Incorrect parameters!", "Balance", MessageBoxButtons.OK);
        }
      }
    }
  }
}
