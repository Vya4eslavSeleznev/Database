using Bank.Exceptions;
using Bank.Models;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Bank.Utils
{
  public static class Helpers
  {
    public static int GetSelectedId(ComboBox cb)
    {
      return ((IEntity)cb.SelectedItem).Id;
    }

    public static bool TryHandleOleDbException(OleDbException ex)
    {
      if (ex.Errors[0].NativeError != 50000)
        return false;

      MessageBox.Show(ex.Errors[0].Message, "Unexpected error", MessageBoxButtons.OK);
      return true;
    }

    public static int GetBalanceIdByCustomerAndCurrency(OleDbConnection connection, int customerId, int currencyId)
    {
      var query = "SELECT TOP(1) BalanceId FROM Balance WHERE CustomerId = ? AND CurrencyId = ?";

      using (var cmd = new OleDbCommand(query, connection))
      {
        cmd.Parameters.Add(new OleDbParameter("@CustomerId", customerId));
        cmd.Parameters.Add(new OleDbParameter("@CurrencyId", currencyId));

        using (var reader = cmd.ExecuteReader())
        {
          while (reader.Read())
            return reader.GetInt32(0);
        }
      }

      throw new BalanceDoesNotExistException();
    }

    public static void ReturnMoneyOnRandomBalance(OleDbConnection connection, int customerId, int amount, int currencyId)
    {
      var balanceId = GetBalanceIdByCustomerAndCurrency(connection, customerId, currencyId);

      var query = "UPDATE Balance SET Cash = Cash + ? WHERE BalanceId = ?";

      using (var cmd = new OleDbCommand(query, connection))
      {
        cmd.Parameters.Add(new OleDbParameter("@Cash", amount));
        cmd.Parameters.Add(new OleDbParameter("@BalanceId", balanceId));

        cmd.ExecuteNonQuery();
      }
    }
  }
}
