﻿using System;

namespace BankingApp.Exceptions
{
  public  class TransactionException : ApplicationException
  {
    public TransactionException(string message) : base(message)
    {
    }

    public TransactionException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}
