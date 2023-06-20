﻿using System;
using BankingApp.Entities.Contracts;

namespace BankingApp.Entities
{
  public class Account : IAccount, ICloneable
  {
    #region Fields
    private Guid _customerID;
    private Guid _accountID;
    private long _accountNumber;
    private decimal _balance;
    #endregion

    #region Properties
    public Guid CustomerID
    {
      get => _customerID;
      set => _customerID = value;
    }

    public Guid AccountID
    {
      get => _accountID;
      set => _accountID = value;
    }

    public long AccountNumber
    {
      get => _accountNumber;
      set
      {
        if (value < 0)
        {
          throw new ArgumentException("Account number negative");
        }
        _accountNumber = value;
      }
    }

    public decimal Balance
    {
      get => _balance;
      set
      {
        if (value < 0)
        {
          throw new ArgumentException("Balance cannot be negative");
        }
        _balance = value;
      }
    }
    #endregion

    #region Constructors
    public Account()
    {
      CustomerID = Guid.Empty;
      AccountID = Guid.Empty;
      AccountNumber = 0;
      Balance = 0;
    }

    public Account(Guid customerID, Guid accountID, long accountNumber, decimal balance)
    {
      CustomerID = customerID;
      AccountID = accountID;
      AccountNumber = accountNumber;
      Balance = balance;
    }
    #endregion

    #region Methods
    public object Clone()
    {
      return new Account(CustomerID = this.CustomerID, AccountID = this.AccountID, AccountNumber = this.AccountNumber, Balance = this.Balance);
    }
    #endregion
  }
}
