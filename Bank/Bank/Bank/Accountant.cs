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
  public partial class Accountant : Form
  {
    public Accountant()
    {
      InitializeComponent();
      connection.Open();
      setDepositTypes();
      //setTopDeposits();
      setCreditTypes();
      setSecurityTypes();
      setTopSecurities();
      setBankPayments();
      setCustomerInformation();
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

    private string depositTypes()
    {
      return
        "SELECT Currency.[Name] AS Currency, InfoDeposit.Term, InfoDeposit.Amount, " +
        "InfoDeposit.[Percent], InfoDeposit.DepositName " +
        "FROM InfoDeposit " +
        "JOIN Currency ON InfoDeposit.CurrencyId = Currency.CurrencyId";
    }

    private string topDeposits()
    {
      return
        "SELECT TOP(10) " +
        "InfoDeposit.DepositName, " +
        "COUNT(*) AS DepositCount, " +
        "InfoDeposit.[Percent], " +
        "InfoDeposit.Amount, " +
        "Currency.Name " +
        "FROM InfoDeposit " +
        "JOIN CustomerDeposit ON InfoDeposit.InfoDepositId = CustomerDeposit.InfoDepositId " +
        "JOIN Currency ON InfoDeposit.CurrencyId = Currency.CurrencyId " +
        "GROUP BY InfoDeposit.DepositName " +
        "HAVING COUNT(*) > 10 " +
        "ORDER BY COUNT(*)";
    }

    private string creditTypes()
    {
      return
        "SELECT InfoCredit.[Name] AS NameOfCredit, Currency.[Name] AS Currency, InfoCredit.[Percent], " +
        "InfoCredit.Term, InfoCredit.Date " +
        "FROM InfoCredit " +
        "JOIN Currency ON InfoCredit.CurrencyId = Currency.CurrencyId";
    }

    private string securityTypes()
    {
      return
        "SELECT InfoSecurities.[Name], InfoSecurities.Price, Currency.[Name] AS Currency, " +
        "InfoSecurities.[Percent rate] " +
        "FROM InfoSecurities " +
        "JOIN Currency ON InfoSecurities.CurrencyId = Currency.CurrencyId";
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

    private string shareOfCurrency()
    {
      return 
        "";
    }

    private string bankPayments()
    {
      return
        "SELECT Currency.[Name], InfoDeposit.DepositName, " +
        "SUM(CustomerDeposit.Amount) * InfoDeposit.[Percent] AS Count " +
        "FROM InfoDeposit " +
        "JOIN CustomerDeposit ON InfoDeposit.InfoDepositId = CustomerDeposit.InfoDepositId " +
        "JOIN Currency ON InfoDeposit.CurrencyId = Currency.CurrencyId " +
        "GROUP BY Currency.[Name], InfoDeposit.DepositName, InfoDeposit.[Percent]";
    }

    private string customerInformation()
    {
      return
        "SELECT Customer.FirstName, Customer.LastName, Customer.Phone, Balance.Cash, " +
        "Balance.Number AS BalanceNumber, [Card].Number AS CardNumber " +
        "FROM Customer " +
        "JOIN Balance ON Customer.CustomerId = Balance.CustomerId " +
        "JOIN BalanceCards ON Balance.BalanceId = BalanceCards.BalanceId " +
        "JOIN[Card] ON BalanceCards.CardId = [Card].CardId";
    }

    private void setDepositTypes()
    {
      string depositTypesQuery = depositTypes();
      setDataInTable(depositTypesQuery, "InfoDeposit", dsDepositTypes, depositDataGridView);
    }

    private void setTopDeposits()
    {
      string topDepositsQuery = topDeposits();
      setDataInTable(topDepositsQuery, "InfoDeposit", dsPopularDeposits, topDepositsDataGridView);
    }

    private void setCreditTypes()
    {
      string creditTypesQuery = creditTypes();
      setDataInTable(creditTypesQuery, "InfoCredit", dsCreditTypes, creditTypesDataGridView);
    }

    private void setSecurityTypes()
    {
      string securityTypesQuery = securityTypes();
      setDataInTable(securityTypesQuery, "InfoSecurities", dsSecurityTypes, securityTypesDataGridView);
    }

    private void setTopSecurities()
    {
      string topSecuritiesQuery = popularSecurities();
      setDataInTable(topSecuritiesQuery, "CustomerSecurities", dsPopularSecurity, topSecurityDataGridView);
    }

    private void setBankPayments()
    {
      string paymentsQuery = bankPayments();
      setDataInTable(paymentsQuery, "InfoDeposit", dsPayments, paymentsDataGridView);
    }

    private void setCustomerInformation()
    {
      string customerInformationQuery = customerInformation();
      setDataInTable(customerInformationQuery, "Customer", dsCustomerInformation, customerInfoDataGridView);
    }

    private void Accountant_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
      Application.Exit();
    }
  }
}
