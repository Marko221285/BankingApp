using System;
using System.Collections.Generic;
using BankingApp.Entities;
using BankingApp.DataAccessLayer.DALContracts;

namespace BankingApp.DataAccessLayer
{
  public class TransactionsDataAccessLayer : ITransactionsDataAccessLayer
  {
    #region Fields
    private static List<Transaction> _transactions;
    #endregion

    #region Constructors
    static TransactionsDataAccessLayer()
    {
      _transactions = new List<Transaction>();
    }
    #endregion

    #region Properties
    public static List<Transaction> Transactions
    {
      get => _transactions;
      set => _transactions = value;
    }
    #endregion

    #region Methods
    public List<Transaction> GetTransactions()
    {
      List<Transaction> transactionsList = new List<Transaction>();
      Transactions.ForEach(t => transactionsList.Add(t.Clone() as Transaction));
      return transactionsList;
    }

    public List<Transaction> GetTransactionsByCondition(Predicate<Transaction> predicate)
    {
      List<Transaction> transactionsList = new List<Transaction>();

      List<Transaction> filteredTransactions = Transactions.FindAll(predicate);
      filteredTransactions.ForEach(t => transactionsList.Add(t.Clone() as Transaction));
      return transactionsList;
    }
    public void AddTransaction(Transaction transaction)
    {
      try
      {
        Transactions.Add(transaction);
      }
      catch (Exception)
      {
        throw;
      }
    }
    #endregion
  }
}
