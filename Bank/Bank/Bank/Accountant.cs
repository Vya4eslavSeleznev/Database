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
      setTopDeposits();
      setCreditTypes();
      setSecurityTypes();
      setTopSecurities();
      setBankPayments();
      setCustomerInformation();
      setShareOfCurrency();
      setMoneyTurnover();
      setPopularCredits();
      setCustomerCredits();
      setCustomerDeposits();
      setCurrencyComboBox(currencyDepositComboBox);
      setCurrencyComboBox(creditCurrencyComboBox);
      setCurrencyComboBox(securityCurrencyComboBox);
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
        "GROUP BY InfoDeposit.DepositName, " +
        "InfoDeposit.[Percent], " +
        "InfoDeposit.Amount, " +
        "Currency.Name " +
        "HAVING COUNT(*) > 10 " +
        "ORDER BY COUNT(*)";
    }

    private string creditTypes()
    {
      return
        "SELECT InfoCredit.[Name] AS NameOfCredit, Currency.[Name] AS Currency, InfoCredit.[Percent], " +
        "InfoCredit.Term " +
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
        "Balance.Number AS BalanceNumber " +//, [Card].Number AS CardNumber " +
        "FROM Customer " +
        "JOIN Balance ON Customer.CustomerId = Balance.CustomerId ";
        //"JOIN BalanceCards ON Balance.BalanceId = BalanceCards.BalanceId " +
        //"JOIN[Card] ON BalanceCards.CardId = [Card].CardId";
    }

    private string popularCredits()
    {
      return
        "SELECT TOP(10) " +
        "InfoCredit.[Name], " +
        "COUNT(*) AS CreditCount " +
        "FROM InfoCredit " +
        "JOIN CustomerCredit ON InfoCredit.InfoCreditId = CustomerCredit.InfoCreditId " +
        "GROUP BY InfoCredit.[Name] " +
        "HAVING COUNT(*) > 10 " +
        "ORDER BY COUNT(*)";
    }

    private string customerCredit()
    {
      return
        "SELECT Customer.FirstName, Customer.LastName, Customer.Phone, InfoCredit.[Name], " +
        "Currency.[Name], CustomerCredit.Amount, InfoCredit.[Percent] " +
        "FROM Customer " +
        "JOIN CustomerCredit ON Customer.CustomerId = CustomerCredit.CustomerId " +
        "JOIN InfoCredit ON CustomerCredit.InfoCreditId = InfoCredit.InfoCreditId " +
        "JOIN Currency ON InfoCredit.CurrencyId = Currency.CurrencyId";
    }

    private string customerDeposit()
    {
      return
        "SELECT Customer.FirstName, Customer.LastName, Customer.Phone, " +
        "InfoDeposit.DepositName, Currency.[Name], CustomerDeposit.Amount, InfoDeposit.[Percent] " +
        "FROM Customer " +
        "JOIN CustomerDeposit ON Customer.CustomerId = CustomerDeposit.CustomerId " +
        "JOIN InfoDeposit ON CustomerDeposit.InfoDepositId = InfoDeposit.InfoDepositId " +
        "JOIN Currency ON InfoDeposit.CurrencyId = Currency.CurrencyId";
    }

    private void setDepositTypes()
    {
      addCheckBoxInDataGrid("Select to delete", depositDataGridView);
      string depositTypesQuery = depositTypes();
      setDataInTable(depositTypesQuery, "InfoDeposit", dsDepositTypes, depositDataGridView);
      addButtonInDataGrid(depositDataGridView);
    }

    private void setTopDeposits()
    {
      string topDepositsQuery = topDeposits();
      setDataInTable(topDepositsQuery, "InfoDeposit", dsPopularDeposits, topDepositsDataGridView);
    }

    private void setCreditTypes()
    {
      addCheckBoxInDataGrid("Select to delete", creditTypesDataGridView);
      string creditTypesQuery = creditTypes();
      setDataInTable(creditTypesQuery, "InfoCredit", dsCreditTypes, creditTypesDataGridView);
      addButtonInDataGrid(creditTypesDataGridView);
    }

    private void setSecurityTypes()
    {
      addCheckBoxInDataGrid("Select to delete", securityTypesDataGridView);
      string securityTypesQuery = securityTypes();
      setDataInTable(securityTypesQuery, "InfoSecurities", dsSecurityTypes, securityTypesDataGridView);
      addButtonInDataGrid(securityTypesDataGridView);
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

    private void setShareOfCurrency()
    {
      string shareOfCurrencyQuery = "CurrencyStatistics";
      setDataInTable(shareOfCurrencyQuery, "CurrencyStatistics", dsShareOfCurrency,
                     shareOfCurrencyDataGridView);
    }

    private void setMoneyTurnover()
    {
      string moneyTurnoverQuery = "MoneyTurnover";
      setDataInTable(moneyTurnoverQuery, "MoneyStatistics", dsTurnover, turnOverDataGridView);
    }

    private void setPopularCredits()
    {
      string popularCreditsQuery = popularCredits();
      setDataInTable(popularCreditsQuery, "InfoCredit", dsPopularCredits, topCreditsDataGridView);
    }

    private void setCustomerCredits()
    {
      addCheckBoxInDataGrid("Select to terminate credit", customerCreditsDataGridView);
      string customerCreditsQuery = customerCredit();
      setDataInTable(customerCreditsQuery, "InfoCredit", dsCustomerCredits, customerCreditsDataGridView);
    }

    private void setCustomerDeposits()
    {
      addCheckBoxInDataGrid("Select to terminate deposit", customerDepositDataGridView);
      string customerDepositsQuery = customerDeposit();
      setDataInTable(customerDepositsQuery, "InfoDeposit", dsCustomerDeposits, customerDepositDataGridView);
    }

    private void setCurrencyComboBox(ComboBox comboBox)
    {
      OleDbCommand command = new OleDbCommand("SELECT CurrencyId, [Name] FROM Currency", connection);
      OleDbDataReader rdr = command.ExecuteReader();
      while (rdr.Read())
        comboBox.Items.Add(rdr["CurrencyId"] + " - " + rdr["Name"]);
      rdr.Close();
    }

    private void Accountant_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
      Application.Exit();
    }

    private void addDepositButton_Click(object sender, EventArgs e)
    {
      var currency = currencyDepositComboBox.Text;
      var term = depositTermTextBox.Text;
      var amountDeposit = amountDepositTextBox.Text;
      var percent = depositPercentTextBox.Text;
      var depositInfo = depositInfoTextBox.Text;

      if (currency == "" || term == "" || amountDeposit == ""
          || percent == "" || depositInfo == "")
      {
        MessageBox.Show("Empty test field!", "Deposit types", MessageBoxButtons.OK);
        return;
      }

      string addDepositQuery =
        "INSERT INTO InfoDeposit(CurrencyId, Term, Amount, [Percent], DepositName) " +
        "VALUES(?, ?, ?, ?, ?)";

      OleDbCommand cmdIC = new OleDbCommand(addDepositQuery, connection);

      cmdIC.Parameters.Add(new OleDbParameter("@CurrencyId", currency));
      cmdIC.Parameters.Add(new OleDbParameter("@Term", term));
      cmdIC.Parameters.Add(new OleDbParameter("@Amount", amountDeposit));
      cmdIC.Parameters.Add(new OleDbParameter("@Percent", percent));
      cmdIC.Parameters.Add(new OleDbParameter("@DepositName", depositInfo));

      parseComboBox(0, currency, cmdIC);

      try
      {
        cmdIC.ExecuteNonQuery();
        MessageBox.Show("Deposit type added successfully!", "Deposit type", MessageBoxButtons.OK);
        string depositTypesQuery = depositTypes();
        refreshDataSet(depositTypesQuery, dsDepositTypes, "InfoDeposit");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Incorrect parameters!", "Deposit types", MessageBoxButtons.OK);
      }
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

    private void addCreditButton_Click(object sender, EventArgs e)
    {
      var currency = creditCurrencyComboBox.Text;
      var term = creditTermTextBox.Text;
      var percent = creditPercentTextBox.Text;
      var info = creditInfoTextBox.Text;

      if (currency == "" || term == "" || percent == "" || info == "")
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
      }
    }

    private void addSecurityButton_Click(object sender, EventArgs e)
    {
      var currency = securityCurrencyComboBox.Text;
      var name = securityNameTextBox.Text;
      var price = securityPriceTextBox.Text;
      var percent = percentTextBox.Text;

      if (currency == "" || name == "" || price == "" || percent == "")
      {
        MessageBox.Show("Empty test field!", "Credit types", MessageBoxButtons.OK);
        return;
      }

      string addSecurityTypeQuery =
        "INSERT INTO InfoSecurities(CurrencyId, [Name], Price, [Percent rate]) " +
        "VALUES(?, ?, ?, ?)";

      OleDbCommand cmdIC = new OleDbCommand(addSecurityTypeQuery, connection);

      cmdIC.Parameters.Add(new OleDbParameter("@CurrencyId", currency));
      cmdIC.Parameters.Add(new OleDbParameter("@Name", name));
      cmdIC.Parameters.Add(new OleDbParameter("@Price", price));
      cmdIC.Parameters.Add(new OleDbParameter("@Percent rate", percent));

      parseComboBox(0, currency, cmdIC);

      try
      {
        cmdIC.ExecuteNonQuery();
        MessageBox.Show("Security type added successfully!", "Securities", MessageBoxButtons.OK);
        string securityTypesQuery = securityTypes();
        refreshDataSet(securityTypesQuery, dsSecurityTypes, "InfoSecurities");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Incorrect parameters!", "Securities", MessageBoxButtons.OK);
      }
    }
  }
}
