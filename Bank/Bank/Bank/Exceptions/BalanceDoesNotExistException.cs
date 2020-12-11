using System;

namespace Bank.Exceptions
{
  public class BalanceDoesNotExistException : Exception
  {
    public BalanceDoesNotExistException() : base("Balance does not exist :(")
    {
    }
  }
}
