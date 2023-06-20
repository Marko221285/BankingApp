using System;
using BankingApp.Entities.Contracts;
using BankingApp.Exceptions;

namespace BankingApp.Entities
{
  public class Transaction : ITransaction, ICloneable
  {
    #region Fields
    private DateTime _transactionDate;
    private long _sourceAccNum;
    private long _destinationAccNum;
    private decimal _amount;
    #endregion

    #region Properties
    public DateTime TransactionDate { get => _transactionDate; set => _transactionDate = value; }
    public long SourceAccNum { get => _sourceAccNum; set => _sourceAccNum = value; }
    public long DestinationAccNum { get => _destinationAccNum; set => _destinationAccNum = value; }
    public decimal Amount
    {
      get => _amount;
      set
      {
        if (value > 0)
        {
          _amount = value;
        }
        else
        {
          throw new TransactionException("Amount value should be positive only.");
        }
      }
    }
    #endregion

    #region Methods
    public object Clone()
    {
      return new Transaction() { TransactionDate = TransactionDate, SourceAccNum = SourceAccNum, DestinationAccNum = DestinationAccNum, Amount = Amount };
    }
    #endregion
  }
}
