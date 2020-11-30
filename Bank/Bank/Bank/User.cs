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

        //TEST
        //firstNameTextBox.Text = Convert.ToString(customerId);
    }

    private void ShowRow()
    {
      dRow = dTable.Rows[iRowID];

      firstNameTextBox.Text = dRow["FirstName"].ToString();
      lastNameTextBox.Text = dRow["LastName"].ToString();

      //TODO: Birthday
      passportNumTextBox.Text = dRow["PassportNum"].ToString();
      phoneTextBox.Text = dRow["Phone"].ToString();
      //TODO Login + Password
    }

    private void FillDataTable()
    {
      var profile =
        "SELECT FirstName, LastName, PassportNum, Phone " +
        "FROM Customer";

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
      DataGridViewCheckBoxColumn deleteOperation = new DataGridViewCheckBoxColumn();
      deleteOperation.HeaderText = "Select to delete";
      deleteOperation.FalseValue = "0";
      deleteOperation.TrueValue = "1";
      operationDataGridView.Columns.Insert(0, deleteOperation);

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

      var dataAdapter = new OleDbDataAdapter(myOperationQuery, connection);
      DataTable customersOperation = new DataTable("Operation");
      dsOperation.Tables.Add(customersOperation);
      operationDataGridView.AutoGenerateColumns = true;
      operationDataGridView.DataSource = dsOperation;
      operationDataGridView.DataMember = "Operation";
      dataAdapter.Fill(dsOperation, "Operation");

      DataGridViewButtonColumn editOperation = new DataGridViewButtonColumn();
      operationDataGridView.Columns.Add(editOperation);
      editOperation.HeaderText = "Click to edit";
      editOperation.Text = "Edit";
      editOperation.Name = "editButton";
      editOperation.UseColumnTextForButtonValue = true;
    }

    private void setBalance()
    {
      DataGridViewCheckBoxColumn deleteBalance = new DataGridViewCheckBoxColumn();
      deleteBalance.HeaderText = "Select to delete";
      deleteBalance.FalseValue = "0";
      deleteBalance.TrueValue = "1";
      balancesDataGridView.Columns.Insert(0, deleteBalance);

      string myBalanceQuery =
        "SELECT Balance.Number, Balance.[Date], Currency.[Name], " +
        "Balance.Debit, Balance.Credit, Balance.CardId " +
        "FROM Balance " +
        "JOIN Currency ON Balance.CurrencyId = Currency.CurrencyId " +
        "WHERE CustomerId = " + customerId;

      var dataAdapter = new OleDbDataAdapter(myBalanceQuery, connection);
      DataTable customersBalance = new DataTable("Balance");
      dsBalance.Tables.Add(customersBalance);
      balancesDataGridView.AutoGenerateColumns = true;
      balancesDataGridView.DataSource = dsBalance;
      balancesDataGridView.DataMember = "Balance";
      dataAdapter.Fill(dsBalance, "Balance");

      DataGridViewButtonColumn editBalance = new DataGridViewButtonColumn();
      balancesDataGridView.Columns.Add(editBalance);
      editBalance.HeaderText = "Click to edit";
      editBalance.Text = "Edit";
      editBalance.Name = "editButton";
      editBalance.UseColumnTextForButtonValue = true;
    }

    private void setMyCards()
    {
      DataGridViewCheckBoxColumn deleteCard = new DataGridViewCheckBoxColumn();
      deleteCard.HeaderText = "Select to delete";
      deleteCard.FalseValue = "0";
      deleteCard.TrueValue = "1";
      cardsDataGridView.Columns.Insert(0, deleteCard);

      string myCardsQuery =
        "SELECT [Card].Number, CardService.[Name] AS Service " +
        "FROM[Card] " +
        "JOIN CardService ON[Card].CardServiceId = CardService.CardServiceId " +
        "JOIN BalanceCards ON[Card].CardId = BalanceCards.BalanceId " +
        "JOIN Balance ON BalanceCards.BalanceId = Balance.BalanceId " +
        "WHERE Balance.CustomerId = " + customerId;

      var dataAdapter = new OleDbDataAdapter(myCardsQuery, connection);
      DataTable customerCards = new DataTable("Card");
      dsCard.Tables.Add(customerCards);
      cardsDataGridView.AutoGenerateColumns = true;
      cardsDataGridView.DataSource = dsCard;
      cardsDataGridView.DataMember = "Card";
      dataAdapter.Fill(dsCard, "Card");

      DataGridViewButtonColumn editCard = new DataGridViewButtonColumn();
      cardsDataGridView.Columns.Add(editCard);
      editCard.HeaderText = "Click to edit";
      editCard.Text = "Edit";
      editCard.Name = "editButton";
      editCard.UseColumnTextForButtonValue = true;
    }

    private void setCardServices()
    {
      string cardServiceQuery =
        "SELECT [Name], Price " +
        "FROM CardService";

      var dataAdapter = new OleDbDataAdapter(cardServiceQuery, connection);
      DataTable cardServices = new DataTable("CardService");
      dsCardService.Tables.Add(cardServices);
      servicesDataGridView.AutoGenerateColumns = true;
      servicesDataGridView.DataSource = dsCardService;
      servicesDataGridView.DataMember = "CardService";
      dataAdapter.Fill(dsCardService, "CardService");
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

      var dataAdapter = new OleDbDataAdapter(myCreditQuery, connection);
      DataTable myCredit = new DataTable("CustomerCredit");
      dsCredit.Tables.Add(myCredit);
      myCreditDataGridView.AutoGenerateColumns = true;
      myCreditDataGridView.DataSource = dsCredit;
      myCreditDataGridView.DataMember = "CustomerCredit";
      dataAdapter.Fill(dsCredit, "CustomerCredit");
    }

    private void setCreditInformation()
    {
      string creditInfoQuery =
        "SELECT InfoCredit.[Name] AS NameOfCredit, Currency.[Name] AS Currency, " +
        "InfoCredit.[Percent], InfoCredit.Term, InfoCredit.Date " +
        "FROM InfoCredit " +
        "JOIN Currency ON InfoCredit.CurrencyId = Currency.CurrencyId";

      var dataAdapter = new OleDbDataAdapter(creditInfoQuery, connection);
      DataTable creditInfo = new DataTable("InfoCredit");
      dsCreditInfo.Tables.Add(creditInfo);
      creditInfoDataGridView.AutoGenerateColumns = true;
      creditInfoDataGridView.DataSource = dsCreditInfo;
      creditInfoDataGridView.DataMember = "InfoCredit";
      dataAdapter.Fill(dsCreditInfo, "InfoCredit");
    }

    private void setMyDeposit()
    {
      DataGridViewCheckBoxColumn selectedDeposits = new DataGridViewCheckBoxColumn();
      selectedDeposits.HeaderText = "Select to terminate";
      selectedDeposits.FalseValue = "0";
      selectedDeposits.TrueValue = "1";
      myDepositsDataGridView.Columns.Insert(0, selectedDeposits);


      string myDepositQuery =
        "SELECT InfoDeposit.DepositName, CustomerDeposit.Amount " +
        "FROM CustomerDeposit " +
        "JOIN InfoDeposit ON CustomerDeposit.InfoDepositId = InfoDeposit.InfoDepositId " +
        "WHERE CustomerId = " + customerId;

      var dataAdapter = new OleDbDataAdapter(myDepositQuery, connection);
      DataTable myDeposit = new DataTable("CustomerDeposit");
      dsMyDeposit.Tables.Add(myDeposit);
      myDepositsDataGridView.AutoGenerateColumns = true;
      myDepositsDataGridView.DataSource = dsMyDeposit;
      myDepositsDataGridView.DataMember = "CustomerDeposit";
      dataAdapter.Fill(dsMyDeposit, "CustomerDeposit");
    }

    private void setDepositInfo()
    {
      string depositInfoQuery =
        "SELECT InfoDeposit.Term, InfoDeposit.Amount, Currency.[Name] AS Currency, " +
        "InfoDeposit.[Percent], InfoDeposit.DepositName " +
        "FROM InfoDeposit " +
        "JOIN Currency ON InfoDeposit.CurrencyId = Currency.CurrencyId";

      var dataAdapter = new OleDbDataAdapter(depositInfoQuery, connection);
      DataTable myDeposit = new DataTable("InfoDeposit");
      dsDepositInfo.Tables.Add(myDeposit);
      depositInfoDataGridView.AutoGenerateColumns = true;
      depositInfoDataGridView.DataSource = dsDepositInfo;
      depositInfoDataGridView.DataMember = "InfoDeposit";
      dataAdapter.Fill(dsDepositInfo, "InfoDeposit");
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

      var dataAdapter = new OleDbDataAdapter(popularDepositsQuery, connection);
      DataTable popularDeposits = new DataTable("InfoDeposit");
      dsTopDeposits.Tables.Add(popularDeposits);
      topDepositsDataGridView.AutoGenerateColumns = true;
      topDepositsDataGridView.DataSource = dsTopDeposits;
      topDepositsDataGridView.DataMember = "InfoDeposit";
      dataAdapter.Fill(dsTopDeposits, "InfoDeposit");
    }

    private void setMySecurities()
    {
      DataGridViewCheckBoxColumn selectedSecurities = new DataGridViewCheckBoxColumn();
      selectedSecurities.HeaderText = "Select to sell";
      selectedSecurities.FalseValue = "0";
      selectedSecurities.TrueValue = "1";
      mySecuritiesDataGridView.Columns.Insert(0, selectedSecurities);

      string mySecuritiesQuery =
        "SELECT InfoSecurities.[Name], CustomerSecurities.Count " +
        "FROM CustomerSecurities " +
        "JOIN InfoSecurities ON CustomerSecurities.InfoSecuritiesId = InfoSecurities.InfoSecuritiesId " +
        "WHERE CustomerId = " + customerId;

      var dataAdapter = new OleDbDataAdapter(mySecuritiesQuery, connection);
      DataTable mySecurities = new DataTable("CustomerSecurities");
      dsMySecurities.Tables.Add(mySecurities);
      mySecuritiesDataGridView.AutoGenerateColumns = true;
      mySecuritiesDataGridView.DataSource = dsMySecurities;
      mySecuritiesDataGridView.DataMember = "CustomerSecurities";
      dataAdapter.Fill(dsMySecurities, "CustomerSecurities");
    }

    private void setSecurityInfo()
    {
      string securityInfoQuery =
        "SELECT InfoSecurities.[Name], InfoSecurities.Price, Currency.[Name] AS Currency, " +
        "InfoSecurities.[Percent rate] " +
        "FROM InfoSecurities " +
        "JOIN Currency ON InfoSecurities.CurrencyId = Currency.CurrencyId";

      var dataAdapter = new OleDbDataAdapter(securityInfoQuery, connection);
      DataTable securityInfo = new DataTable("InfoSecurities");
      dsSecurityInfo.Tables.Add(securityInfo);
      securityInfoDataGridView.AutoGenerateColumns = true;
      securityInfoDataGridView.DataSource = dsSecurityInfo;
      securityInfoDataGridView.DataMember = "InfoSecurities";
      dataAdapter.Fill(dsSecurityInfo, "InfoSecurities");
    }

    private void setPopularSecurities()
    {
      string topSecuritysQuery =
        "SELECT Name, SUM(CustomerSecurities.Count), [Percent rate] " +
        "FROM CustomerSecurities " +
        "JOIN InfoSecurities ON CustomerSecurities.InfoSecuritiesId = InfoSecurities.InfoSecuritiesId " +
        "GROUP BY Name, [Percent rate] " +
        "ORDER BY COUNT(*) DESC";

      var dataAdapter = new OleDbDataAdapter(topSecuritysQuery, connection);
      DataTable topSecuritys = new DataTable("InfoSecurities");
      dsTopSecurities.Tables.Add(topSecuritys);
      topSecuritiesDataGridView.AutoGenerateColumns = true;
      topSecuritiesDataGridView.DataSource = dsTopSecurities;
      topSecuritiesDataGridView.DataMember = "InfoSecurities";
      dataAdapter.Fill(dsTopSecurities, "InfoSecurities");
    }

      private void User_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
      Application.Exit();
    }
  }
}
