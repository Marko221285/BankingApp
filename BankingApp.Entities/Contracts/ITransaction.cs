using System;

namespace BankingApp.Entities.Contracts
{
  public interface ITransaction
  {
    DateTime TransactionDate { get; set; }
    long SourceAccNum { get; set; }
    long DestinationAccNum { get; set; }
    decimal Amount { get; set; }
  }
}
