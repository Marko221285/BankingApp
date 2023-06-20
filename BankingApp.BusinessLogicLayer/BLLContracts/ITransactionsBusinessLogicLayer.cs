using System;
using System.Collections.Generic;
using BankingApp.Entities;

namespace BankingApp.BusinessLogicLayer.BLLContracts
{
  public interface ITransactionsBusinessLogicLayer
  {
    List<Transaction> GetTransactions();

    List<Transaction> GetTransactionsByCondition(Predicate<Transaction> predicate);

    void AddTransaction(Transaction transaction);
  }
}

