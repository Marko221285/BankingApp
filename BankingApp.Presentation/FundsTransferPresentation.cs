using System;
using System.Collections.Generic;
using System.Linq;
using BankingApp.BusinessLogicLayer.BLLContracts;
using BankingApp.BusinessLogicLayer;
using BankingApp.Entities;

namespace BankingApp.Presentation
{
  static class FundsTransferPresentation
  {
    internal static void FundsTransfer()
    {
      try
      {
        IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();

        List<Account> allAccounts = accountsBusinessLogicLayer.GetAccounts();
        if (allAccounts.Count == 0)
        {
          Console.WriteLine("\nNo accounts");
          return;
        }

        Transaction transaction = new Transaction();

        ITransactionsBusinessLogicLayer transactionsBusinessLogicLayer = new TransactionBusinessLogicLayer();

        Console.WriteLine("\n********ALL ACCOUNTS********");
        AccountsPresentation.ViewAccounts();

        Console.Write("Enter the Source Account Number: ");
        long accountNoSource;
        while (!long.TryParse(Console.ReadLine(), out accountNoSource))
        {
          Console.Write("Enter the Source Account Number: ");
        }
        Account sourceAccount = accountsBusinessLogicLayer.GetAccountsByCondition(acc => acc.AccountNumber == accountNoSource).FirstOrDefault();
        if (sourceAccount == null)
        {
          Console.Write("\nNo such Account Number. Try again!\n");
          return;
        }
        transaction.SourceAccNum = accountNoSource;

        Console.Write("Enter the Destination Account Number: ");
        long accountNoDestination;
        while (!long.TryParse(Console.ReadLine(), out accountNoDestination))
        {
          Console.Write("Enter the Destination Account Number: ");
        }
        Account destinationAccount = accountsBusinessLogicLayer.GetAccountsByCondition(acc => acc.AccountNumber == accountNoDestination).FirstOrDefault();
        if (destinationAccount == null)
        {
          Console.Write("\nNo such Account Number. Try again!\n");
          return;
        }
        transaction.DestinationAccNum = accountNoDestination;

        Console.Write("Amount: ");
        decimal amount;
        while (!decimal.TryParse(Console.ReadLine(), out amount))
        {
          Console.Write("Amount: ");
        }
        transaction.Amount = amount;

        transaction.TransactionDate = DateTime.Now;

        sourceAccount.Balance -= amount;
        destinationAccount.Balance += amount;

        transactionsBusinessLogicLayer.AddTransaction(transaction);
        bool isTransferedSource = accountsBusinessLogicLayer.UpdateAccount(sourceAccount);
        bool isTransferedDestination = accountsBusinessLogicLayer.UpdateAccount(destinationAccount);

        if (isTransferedSource && isTransferedDestination)
        {
          Console.WriteLine("\nTransaction successful");
          Console.WriteLine($"Account Balance of source account number {accountNoSource} is: {sourceAccount.Balance}");
          Console.WriteLine($"Account Balance of destination account number {accountNoDestination} is: {destinationAccount.Balance}");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.GetType());
      }
    }
  }
}
