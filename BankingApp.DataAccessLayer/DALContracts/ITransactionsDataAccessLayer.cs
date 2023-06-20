using System;
using System.Collections.Generic;
using BankingApp.Entities;

namespace BankingApp.DataAccessLayer.DALContracts
{
  public interface ITransactionsDataAccessLayer
  {
    List<Transaction> GetTransactions();

    List<Transaction> GetTransactionsByCondition(Predicate<Transaction> predicate);

    void AddTransaction(Transaction transaction);
  }
}
