using System;
using System.Collections.Generic;
using BankingApp.Entities;
using BankingApp.BusinessLogicLayer.BLLContracts;
using BankingApp.DataAccessLayer;
using BankingApp.DataAccessLayer.DALContracts;

namespace BankingApp.BusinessLogicLayer
{
  public class TransactionBusinessLogicLayer : ITransactionsBusinessLogicLayer
  {
    #region Fields
    private ITransactionsDataAccessLayer _transactionsDataAccesslayer;
    #endregion

    #region Constructors
    public TransactionBusinessLogicLayer()
    {
      _transactionsDataAccesslayer = new TransactionsDataAccessLayer();
    }
    #endregion

    #region Properties
    private ITransactionsDataAccessLayer TransactionsDataAccessLayer
    {
      get => _transactionsDataAccesslayer;
      set => _transactionsDataAccesslayer = value;
    }
    #endregion

    #region Methods
    public List<Transaction> GetTransactions()
    {
      try
      {
        return TransactionsDataAccessLayer.GetTransactions();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Transaction> GetTransactionsByCondition(Predicate<Transaction> predicate)
    {
      try
      {
        return TransactionsDataAccessLayer.GetTransactionsByCondition(predicate);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public void AddTransaction(Transaction transaction)
    {
      try
      {
        TransactionsDataAccessLayer.AddTransaction(transaction);
      }
      catch (Exception)
      {
        throw;
      }
    }
    #endregion
  }
}
