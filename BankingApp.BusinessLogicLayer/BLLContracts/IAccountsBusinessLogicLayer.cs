using System;
using System.Collections.Generic;
using BankingApp.Entities;

namespace BankingApp.BusinessLogicLayer.BLLContracts
{
  public interface IAccountsBusinessLogicLayer
  {
    List<Account> GetAccounts();

    List<Account> GetAccountsByCondition(Predicate<Account> predicate);

    long AddAccount(Account account);

    bool UpdateAccount(Account account);

    bool DeleteAccount(Guid accountID);
  }
}
