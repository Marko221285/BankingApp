using System;
using System.Collections.Generic;
using BankingApp.Entities;
using BankingApp.DataAccessLayer.DALContracts;
using BankingApp.Exceptions;

namespace BankingApp.DataAccessLayer
{
  public class AccountsDataAccessLayer : IAccountsDataAccessLayer
  {
    #region Fields
    private static List<Account> _accounts;
    #endregion

    #region Constructors
    static AccountsDataAccessLayer()
    {
      _accounts = new List<Account>();
    }
    #endregion

    #region Properties
    private static List<Account> Accounts
    {
      get => _accounts;
      set => _accounts = value;
    }
    #endregion

    #region Methods
    public List<Account> GetAccounts()
    {
      try
      {
        List<Account> accountsList = new List<Account>();

        Accounts.ForEach(acc => accountsList.Add(acc.Clone() as Account));
        return accountsList;
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

    public List<Account> GetAccountsByCondition(Predicate<Account> predicate)
    {
      try
      {
        List<Account> accountsList = new List<Account>();

        List<Account> filteredAccounts = Accounts.FindAll(predicate);
        filteredAccounts.ForEach(item => accountsList.Add(item.Clone() as Account));
        return accountsList;
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
        account.AccountID = Guid.NewGuid();

        Accounts.Add(account);

        return account.AccountNumber;

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
        Account existingAccount = Accounts.Find(item => item.AccountID == account.AccountID);

        if (existingAccount != null)
        {
          existingAccount.Balance = account.Balance;

          return true;
        }
        else
        {
          return false;
        }
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

    public bool DeleteAccount(Guid AccountID)
    {
      try
      {
        if (Accounts.RemoveAll(acc => acc.AccountID == AccountID) > 0)
        {
          return true;
        }
        else
        {
          return false;
        }
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
