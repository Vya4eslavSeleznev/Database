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
using Bank.Utils;
using Bank.Exceptions;

namespace Bank
{
  public partial class Accountant : Form
  {
    private readonly Authentication authentication;

    public Accountant(Authentication authentication)
    {
      InitializeComponent();

      this.authentication = authentication;

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
        "SELECT InfoDeposit.InfoDepositId, Currency.[Name] AS Currency, " +
        "InfoDeposit.Term, InfoDeposit.Amount, " +
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
        "SELECT InfoCredit.InfoCreditId, InfoCredit.[Name] AS NameOfCredit, " +
        "Currency.[Name] AS Currency, InfoCredit.[Percent], " +
        "InfoCredit.Term " +
        "FROM InfoCredit " +
        "JOIN Currency ON InfoCredit.CurrencyId = Currency.CurrencyId";
    }

    private string securityTypes()
    {
      return
        "SELECT InfoSecurities.InfoSecuritiesId, InfoSecurities.[Name], " +
        "InfoSecurities.Price, Currency.[Name] AS Currency, " +
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
        "SELECT Balance.BalanceId, Customer.FirstName, Customer.LastName, Customer.Phone, Balance.Cash, " +
        "Currency.[Name], Balance.Number AS BalanceNumber " +
        "FROM Customer " +
        "JOIN Balance ON Customer.CustomerId = Balance.CustomerId " +
        "JOIN Currency ON Balance.CurrencyId = Currency.CurrencyId";
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
        "SELECT CustomerCredit.CustomerCreditId, Customer.FirstName, Customer.LastName, " +
        "Customer.Phone, InfoCredit.[Name], " +
        "Currency.[Name], CustomerCredit.Amount, InfoCredit.[Percent] " +
        "FROM Customer " +
        "JOIN CustomerCredit ON Customer.CustomerId = CustomerCredit.CustomerId " +
        "JOIN InfoCredit ON CustomerCredit.InfoCreditId = InfoCredit.InfoCreditId " +
        "JOIN Currency ON InfoCredit.CurrencyId = Currency.CurrencyId";
    }

    private string customerDeposit()
    {
      return
        "SELECT CustomerDeposit.CustomerDepositId, Customer.CustomerId, Customer.FirstName, " +
        "Customer.LastName, Customer.Phone, " +
        "InfoDeposit.DepositName, Currency.[Name], " +
        "CustomerDeposit.Amount, InfoDeposit.[Percent], InfoDeposit.CurrencyId " +
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
      depositDataGridView.Columns["InfoDepositId"].Visible = false;
    }

    private void setTopDeposits()
    {
      string topDepositsQuery = topDeposits();
      setDataInTable(topDepositsQuery, "InfoDeposit", dsPopularDeposits, topDepositsDataGridView);
      topDepositsDataGridView.ReadOnly = true;
    }

    private void setCreditTypes()
    {
      addCheckBoxInDataGrid("Select to delete", creditTypesDataGridView);
      string creditTypesQuery = creditTypes();
      setDataInTable(creditTypesQuery, "InfoCredit", dsCreditTypes, creditTypesDataGridView);
      addButtonInDataGrid(creditTypesDataGridView);
      creditTypesDataGridView.Columns["InfoCreditId"].Visible = false;
    }

    private void setSecurityTypes()
    {
      addCheckBoxInDataGrid("Select to delete", securityTypesDataGridView);
      string securityTypesQuery = securityTypes();
      setDataInTable(securityTypesQuery, "InfoSecurities", dsSecurityTypes, securityTypesDataGridView);
      addButtonInDataGrid(securityTypesDataGridView);
      securityTypesDataGridView.Columns["InfoSecuritiesId"].Visible = false;
    }

    private void setTopSecurities()
    {
      string topSecuritiesQuery = popularSecurities();
      setDataInTable(topSecuritiesQuery, "CustomerSecurities", dsPopularSecurity, topSecurityDataGridView);
      topSecurityDataGridView.ReadOnly = true;
    }

    private void setBankPayments()
    {
      string paymentsQuery = bankPayments();
      setDataInTable(paymentsQuery, "InfoDeposit", dsPayments, paymentsDataGridView);
      paymentsDataGridView.ReadOnly = true;
    }

    private void setCustomerInformation()
    {
      string customerInformationQuery = customerInformation();
      addCheckBoxInDataGrid("Select to update cash", customerInfoDataGridView);
      setDataInTable(customerInformationQuery, "Customer", dsCustomerInformation, customerInfoDataGridView);

      customerInfoDataGridView.Columns["BalanceId"].Visible = false;
    }

    private void setShareOfCurrency()
    {
      string shareOfCurrencyQuery = "CurrencyStatistics";
      setDataInTable(shareOfCurrencyQuery, "CurrencyStatistics", dsShareOfCurrency,
                     shareOfCurrencyDataGridView);
      shareOfCurrencyDataGridView.ReadOnly = true;
    }

    private void setMoneyTurnover()
    {
      string moneyTurnoverQuery = "MoneyTurnover";
      setDataInTable(moneyTurnoverQuery, "MoneyStatistics", dsTurnover, turnOverDataGridView);
      turnOverDataGridView.ReadOnly = true;
    }

    private void setPopularCredits()
    {
      string popularCreditsQuery = popularCredits();
      setDataInTable(popularCreditsQuery, "InfoCredit", dsPopularCredits, topCreditsDataGridView);
      topCreditsDataGridView.ReadOnly = true;
    }

    private void setCustomerCredits()
    {
      addCheckBoxInDataGrid("Select to terminate credit", customerCreditsDataGridView);
      string customerCreditsQuery = customerCredit();
      setDataInTable(customerCreditsQuery, "CustomerCredits", dsCustomerCredits, customerCreditsDataGridView);
      customerCreditsDataGridView.Columns["CustomerCreditId"].Visible = false;
    }

    private void setCustomerDeposits()
    {
      addCheckBoxInDataGrid("Select to terminate deposit", customerDepositDataGridView);
      string customerDepositsQuery = customerDeposit();
      setDataInTable(customerDepositsQuery, "CustomerDeposit", dsCustomerDeposits, customerDepositDataGridView);
      customerDepositDataGridView.Columns["CustomerDepositId"].Visible = false;
      customerDepositDataGridView.Columns["CustomerId"].Visible = false;
      customerDepositDataGridView.Columns["CurrencyId"].Visible = false;
    }

    private void setCurrencyComboBox(ComboBox comboBox)
    {
      using (var command = new OleDbCommand("SELECT CurrencyId, [Name] FROM Currency", connection))
      using (var rdr = command.ExecuteReader())
      {
        while (rdr.Read())
          comboBox.Items.Add(new Currency(rdr.GetInt32(0), rdr.GetString(1)));
      }
    }

    private void Accountant_FormClosing(object sender, FormClosingEventArgs e)
    {
      connection.Close();
      this.authentication.Visible = true;
    }

    private void addDepositButton_Click(object sender, EventArgs e)
    {
      var term = depositTermTextBox.Text;
      var amountDeposit = amountDepositTextBox.Text;
      var percent = depositPercentTextBox.Text;
      var depositInfo = depositInfoTextBox.Text;

      if (currencyDepositComboBox.SelectedItem == null || term == "" || amountDeposit == ""
          || percent == "" || depositInfo == "")
      {
        MessageBox.Show("Empty test field!", "Deposit types", MessageBoxButtons.OK);
        return;
      }

      var currencyId = Helpers.GetSelectedId(currencyDepositComboBox);

      string addDepositQuery =
        "INSERT INTO InfoDeposit(CurrencyId, Term, Amount, [Percent], DepositName) " +
        "VALUES(?, ?, ?, ?, ?)";

      OleDbCommand cmdIC = new OleDbCommand(addDepositQuery, connection);

      cmdIC.Parameters.Add(new OleDbParameter("@CurrencyId", currencyId));
      cmdIC.Parameters.Add(new OleDbParameter("@Term", term));
      cmdIC.Parameters.Add(new OleDbParameter("@Amount", amountDeposit));
      cmdIC.Parameters.Add(new OleDbParameter("@Percent", percent));
      cmdIC.Parameters.Add(new OleDbParameter("@DepositName", depositInfo));

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

    private void refreshDataSet(string query, DataSet ds, string table)
    {
      var command = new OleDbCommand(query, connection);
      var dataAdapter = new OleDbDataAdapter(command);
      ds.Clear();
      dataAdapter.Fill(ds, table);
    }

    private void addCreditButton_Click(object sender, EventArgs e)
    {
      var term = creditTermTextBox.Text;
      var percent = creditPercentTextBox.Text;
      var info = creditInfoTextBox.Text;

      if (creditCurrencyComboBox.SelectedItem == null || term == "" || percent == "" || info == "")
      {
        MessageBox.Show("Empty test field!", "Credit types", MessageBoxButtons.OK);
        return;
      }

      var currencyId = Helpers.GetSelectedId(creditCurrencyComboBox);

      string addCreditTypeQuery =
        "INSERT INTO InfoCredit([Name], CurrencyId, [Percent], Term) " +
        "VALUES(?, ?, ?, ?)";

      OleDbCommand cmdIC = new OleDbCommand(addCreditTypeQuery, connection);

      cmdIC.Parameters.Add(new OleDbParameter("@Name", info));
      cmdIC.Parameters.Add(new OleDbParameter("@CurrencyId", currencyId));
      cmdIC.Parameters.Add(new OleDbParameter("@Percent", percent));
      cmdIC.Parameters.Add(new OleDbParameter("@Term", term));

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
      var name = securityNameTextBox.Text;
      var price = securityPriceTextBox.Text;
      var percent = percentTextBox.Text;

      if (securityCurrencyComboBox.SelectedItem == null || name == "" || price == "" || percent == "")
      {
        MessageBox.Show("Empty test field!", "Credit types", MessageBoxButtons.OK);
        return;
      }

      var currencyId = Helpers.GetSelectedId(securityCurrencyComboBox);

      string addSecurityTypeQuery =
        "INSERT INTO InfoSecurities(CurrencyId, [Name], Price, [Percent rate]) " +
        "VALUES(?, ?, ?, ?)";

      OleDbCommand cmdIC = new OleDbCommand(addSecurityTypeQuery, connection);

      cmdIC.Parameters.Add(new OleDbParameter("@CurrencyId", currencyId));
      cmdIC.Parameters.Add(new OleDbParameter("@Name", name));
      cmdIC.Parameters.Add(new OleDbParameter("@Price", price));
      cmdIC.Parameters.Add(new OleDbParameter("@Percent rate", percent));

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

    public void RefreshDepositInfoDataGrid()
    {
      depositDataGridView.Columns.Clear();
      dsDepositTypes = new DataSet();

      setDepositTypes();
    }

    public void RefreshCreditInfoDataGrid()
    {
      creditTypesDataGridView.Columns.Clear();
      dsCreditTypes = new DataSet();

      setCreditTypes();
    }

    public void RefreshSecurityInfoDataGrid()
    {
      securityTypesDataGridView.Columns.Clear();
      dsSecurityTypes = new DataSet();

      setSecurityTypes();
    }

    public void RefreshCustomerCreditsInfoDataGrid()
    {
      customerCreditsDataGridView.Columns.Clear();
      dsCustomerCredits = new DataSet();

      setCustomerCredits();
    }

    public void RefreshCustomerDepositInfoDataGrid()
    {
      customerDepositDataGridView.Columns.Clear();
      dsCustomerDeposits = new DataSet();

      setCustomerDeposits();
    }

    public void RefreshCustomerBalances()
    {
      customerInfoDataGridView.Columns.Clear();
      dsCustomerInformation = new DataSet();

      setCustomerInformation();
    }

    private void deleteDepositButton_Click(object sender, EventArgs e)
    {
      List<int> depositIds = null;

      try
      {
        depositIds = (from DataGridViewRow r in depositDataGridView.Rows
                         where (string)r.Cells[0].Value == "1"
                         select (int)r.Cells["InfoDepositId"].Value).ToList();
      }
      catch
      {
        MessageBox.Show("Incorrect type of deposit!", "Deposit", MessageBoxButtons.OK);
        return;
      }

      var parametersPart = string.Join(",", depositIds.Select(x => "?"));
      var query = $"DELETE FROM InfoDeposit WHERE InfoDepositId IN ({parametersPart})";

      try
      {
        using (var cmd = new OleDbCommand(query, connection))
        {
          for (var i = 0; i < depositIds.Count; i++)
            cmd.Parameters.Add(new OleDbParameter($"@InfoDepositId{i}", depositIds[i]));

          cmd.ExecuteNonQuery();
        }
      }
      catch
      {
        MessageBox.Show("Incorrect type of deposit!", "Deposit", MessageBoxButtons.OK);
        return;
      }

      RefreshDepositInfoDataGrid();
    }

    private void deleteCreditButton_Click(object sender, EventArgs e)
    {
      List<int> creditIds = null;

      try
      {
        creditIds = (from DataGridViewRow r in creditTypesDataGridView.Rows
                      where (string)r.Cells[0].Value == "1"
                      select (int)r.Cells["InfoCreditId"].Value).ToList();
      }
      catch
      {
        MessageBox.Show("Incorrect type of credit!", "Credit", MessageBoxButtons.OK);
        return;
      }

      var parametersPart = string.Join(",", creditIds.Select(x => "?"));
      var query = $"DELETE FROM InfoCredit WHERE InfoCreditId IN ({parametersPart})";

      try
      {
        using (var cmd = new OleDbCommand(query, connection))
        {
          for (var i = 0; i < creditIds.Count; i++)
            cmd.Parameters.Add(new OleDbParameter($"@InfoCreditId{i}", creditIds[i]));

          cmd.ExecuteNonQuery();
        }
      }
      catch
      {
        MessageBox.Show("Incorrect type of credit!", "Credit", MessageBoxButtons.OK);
        return;
      }

      RefreshCreditInfoDataGrid();
    }

    private void deleteSecurityButton_Click(object sender, EventArgs e)
    {
      List<int> securityIds = null;

      try
      {
        securityIds = (from DataGridViewRow r in securityTypesDataGridView.Rows
                     where (string)r.Cells[0].Value == "1"
                     select (int)r.Cells["InfoSecuritiesId"].Value).ToList();
      }
      catch
      {
        MessageBox.Show("Incorrect type of security!", "Security", MessageBoxButtons.OK);
        return;
      }

      var parametersPart = string.Join(",", securityIds.Select(x => "?"));
      var query = $"DELETE FROM InfoSecurities WHERE InfoSecuritiesId IN ({parametersPart})";

      try
      {
        using (var cmd = new OleDbCommand(query, connection))
        {
          for (var i = 0; i < securityIds.Count; i++)
            cmd.Parameters.Add(new OleDbParameter($"@InfoSecuritiesId{i}", securityIds[i]));

          cmd.ExecuteNonQuery();
        }
      }
      catch
      {
        MessageBox.Show("Incorrect type of security!", "Security", MessageBoxButtons.OK);
        return;
      }

      RefreshSecurityInfoDataGrid();
    }

    private void terminateCustomerCreditButton_Click(object sender, EventArgs e)
    {
      List<int> customerCreditIds = null;

      try
      {
        customerCreditIds = (from DataGridViewRow r in customerCreditsDataGridView.Rows
                       where (string)r.Cells[0].Value == "1"
                       select (int)r.Cells["CustomerCreditId"].Value).ToList();
      }
      catch
      {
        MessageBox.Show("Incorrect customer!", "Debit", MessageBoxButtons.OK);
        return;
      }

      var parametersPart = string.Join(",", customerCreditIds.Select(x => "?"));
      var query = $"DELETE FROM CustomerCredit WHERE CustomerCreditId IN ({parametersPart})";

      try
      {
        using (var cmd = new OleDbCommand(query, connection))
        {
          for (var i = 0; i < customerCreditIds.Count; i++)
            cmd.Parameters.Add(new OleDbParameter($"@CustomerCreditId{i}", customerCreditIds[i]));

          cmd.ExecuteNonQuery();
        }
      }
      catch
      {
        MessageBox.Show("Incorrect customer!", "Debit", MessageBoxButtons.OK);
        return;
      }

      RefreshCustomerCreditsInfoDataGrid();
    }

    private void RemoveCustomerDeposite(int id)
    {
      var query = $"DELETE FROM CustomerDeposit WHERE CustomerDepositId = ?";

      using (var cmd = new OleDbCommand(query, connection))
      {
        cmd.Parameters.Add(new OleDbParameter("@CustomerDepositId", id));

        cmd.ExecuteNonQuery();
      }
    }

    private void terminateDepositButton_Click(object sender, EventArgs e)
    {
      try
      {
        var depositsToTerminate = (from DataGridViewRow r in customerDepositDataGridView.Rows
                                   where (string)r.Cells[0].Value == "1"
                                   select new
                                   {
                                     Id = (int)r.Cells["CustomerDepositId"].Value,
                                     CustomerId = (int)r.Cells["CustomerId"].Value,
                                     CurrencyId = (int)r.Cells["CurrencyId"].Value,
                                     Amount = (int)r.Cells["Amount"].Value,
                                     Percent = (int)r.Cells["Percent"].Value,
                                   }).ToList();

        foreach(var deposit in depositsToTerminate)
        {
          var amount = (int)Math.Floor(deposit.Amount * (100 + deposit.Percent) / (decimal)100);

          Helpers.ReturnMoneyOnRandomBalance(connection, deposit.CustomerId, amount, deposit.CurrencyId);
          RemoveCustomerDeposite(deposit.Id);
        }
      }
      catch (OleDbException ex)
      {
        if (Helpers.TryHandleOleDbException(ex))
          return;

        throw;
      }
      catch(BalanceDoesNotExistException ex)
      {
        MessageBox.Show(ex.Message, "Debit", MessageBoxButtons.OK);
        return;
      }
      catch (Exception ex)
      {
        MessageBox.Show("Incorrect customer!", "Debit", MessageBoxButtons.OK);
        return;
      }

      RefreshCustomerDepositInfoDataGrid();
      RefreshCustomerBalances();
    }

    private void depositDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      var senderGrid = (DataGridView)sender;

      if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
      {
        try
        {
          var depositTypeId = (int)depositDataGridView["InfoDepositId", e.RowIndex].Value;

          using (var editDeposit = new EditDeposit(depositTypeId, this))
          {
            editDeposit.ShowDialog();
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show("Incorrect parameters!", "Deposit type", MessageBoxButtons.OK);
        }
      }
    }

    private void creditTypesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      var senderGrid = (DataGridView)sender;

      if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
      {
        try
        {
          var creditTypeId = (int)creditTypesDataGridView["InfoCreditId", e.RowIndex].Value;

          using (var editCredit = new EditCredit(creditTypeId, this))
          {
            editCredit.ShowDialog();
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show("Incorrect parameters!", "Credit type", MessageBoxButtons.OK);
        }
      }
    }

    private void securityTypesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      var senderGrid = (DataGridView)sender;

      if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
      {
        try
        {
          var securityTypeId = (int)securityTypesDataGridView["InfoSecuritiesId", e.RowIndex].Value;

          using (var editSecurity = new EditSecurity(securityTypeId, this))
          {
            editSecurity.ShowDialog();
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show("Incorrect parameters!", "Security type", MessageBoxButtons.OK);
        }
      }
    }

    private void customerWriteOffMoneyButton_Click(object sender, EventArgs e)
    {
      AmendCustomerBalance(true);
    }

    private void topUpButton_Click(object sender, EventArgs e)
    {
      AmendCustomerBalance(false);
    }

    private void AmendCustomerBalance(bool isWriteOff)
    {
      var cash = customerCashTextBox.Text;

      if (string.IsNullOrEmpty(cash))
        return;

      try
      {
        var balanceIds = (from DataGridViewRow r in customerInfoDataGridView.Rows
                          where (string)r.Cells[0].Value == "1"
                          select (int)r.Cells["BalanceId"].Value).ToList();

        if (balanceIds.Count == 0)
          return;

        var balanceIdsParams = string.Join(",", balanceIds.Select(x => "?"));
        var query = $"UPDATE Balance SET Cash = Cash + ? WHERE BalanceId IN ({balanceIdsParams})";

        using (var cmd = new OleDbCommand(query, connection))
        {
          cmd.Parameters.Add(new OleDbParameter("@Cash", isWriteOff ? $"-{cash}" : cash));

          for (var i = 0; i < balanceIds.Count; i++)
            cmd.Parameters.Add(new OleDbParameter($"@BalanceId{i}", balanceIds[i]));

          cmd.ExecuteNonQuery();
        }
      }
      catch (OleDbException ex)
      {
        if (Helpers.TryHandleOleDbException(ex))
          return;

        throw;
      }
      catch (Exception ex)
      {
        MessageBox.Show("Invalid parameters", "Customer balance", MessageBoxButtons.OK);
      }

      RefreshCustomerBalances();
    }
  }
}
