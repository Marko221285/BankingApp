using System;
using System.Collections.Generic;
using BankingApp.Entities;
using BankingApp.BusinessLogicLayer.BLLContracts;
using BankingApp.DataAccessLayer;
using BankingApp.DataAccessLayer.DALContracts;
using BankingApp.Configuration;
using BankingApp.Exceptions;

namespace BankingApp.BusinessLogicLayer
{
  public class AccountsBusinessLogicLayer : IAccountsBusinessLogicLayer
  {
    #region Fields
    private IAccountsDataAccessLayer _accountsDataAccessLayer;
    #endregion

    #region Constructors
    public AccountsBusinessLogicLayer()
    {
      _accountsDataAccessLayer = new AccountsDataAccessLayer();
    }
    #endregion

    #region Properties
    private IAccountsDataAccessLayer AccountsDataAccessLayer
    {
      get => _accountsDataAccessLayer;
      set => _accountsDataAccessLayer = value;
    }
    #endregion

    #region Methods
    public List<Account> GetAccounts()
    {
      try
      {
        return AccountsDataAccessLayer.GetAccounts();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Account> GetAccountsByCondition(Predicate<Account> predicate)
    {
      try
      {
        return AccountsDataAccessLayer.GetAccountsByCondition(predicate);
      }
      catch (AccountException)
      {
        throw;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public long AddAccount(Account account)
    {
      try
      {
        account.AccountNumber = ++Settings.BaseAccountNo;

        return AccountsDataAccessLayer.AddAccount(account);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public bool DeleteAccount(Guid accountID)
    {
      try
      {
        return AccountsDataAccessLayer.DeleteAccount(accountID);
      }
      catch (AccountException)
      {
        throw;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public bool UpdateAccount(Account account)
    {
      try
      {
        return AccountsDataAccessLayer.UpdateAccount(account);
      }
      catch (AccountException)
      {
        throw;
      }
      catch (Exception)
      {

        throw;
      }
    }
    #endregion
  }
}
