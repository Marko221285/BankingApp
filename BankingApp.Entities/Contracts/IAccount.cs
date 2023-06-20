using System;

namespace BankingApp.Entities.Contracts
{
  public interface IAccount
  {
    #region Properties
    Guid CustomerID { get; set; }
    Guid AccountID { get; set; }
    long AccountNumber { get; set; }
    decimal Balance { get; set; }
    #endregion
  }
}
