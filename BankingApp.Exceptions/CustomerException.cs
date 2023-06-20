using System;

namespace BankingApp.Exceptions
{
  public class CustomerException : ApplicationException
  {
    public CustomerException(string message) : base(message)
    {
    }

    public CustomerException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}
