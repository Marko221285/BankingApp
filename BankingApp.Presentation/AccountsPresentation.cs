using System;
using System.Collections.Generic;
using System.Linq;
using BankingApp.Entities;
using BankingApp.BusinessLogicLayer;
using BankingApp.BusinessLogicLayer.BLLContracts;

namespace BankingApp.Presentation
{
  static class AccountsPresentation
  {
    internal static void AddAccount()
    {
      try
      {
        Account account = new Account();

        ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();
        IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();

        if (customersBusinessLogicLayer.GetCustomers().Count <= 0)
        {
          Console.WriteLine("\nNo customers exist");
          return;
        }

        Console.WriteLine("\n********ADD ACCOUNT********");
        CustomersPresentation.ViewCustomers();

        Console.Write("Enter the Customer Code for which you want to create a new account: ");
        long customerCodeToCreate;
        while (!long.TryParse(Console.ReadLine(), out customerCodeToCreate))
        {
          Console.Write("Enter the Customer Code for which you want to create a new account: ");
        }

        Customer existingCustomer = customersBusinessLogicLayer.GetCustomersByCondition(cust => cust.CustomerCode == customerCodeToCreate).FirstOrDefault();
        if (existingCustomer == null)
        {
          Console.WriteLine("\nInvalid Customer Code.");
          return;
        }
        account.CustomerID = existingCustomer.CustomerID;

        long newAccountNo = accountsBusinessLogicLayer.AddAccount(account);

        Console.WriteLine("\n" + newAccountNo);
        Console.WriteLine("Account added.");

      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.GetType());
      }
    }

    internal static void ViewAccounts()
    {
      try
      {
        IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();

        if (accountsBusinessLogicLayer.GetAccounts().Count <= 0)
        {
          Console.WriteLine("\nNo accounts exist");
          return;
        }

        ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

        List<Account> allAccounts = accountsBusinessLogicLayer.GetAccounts();
        if (allAccounts.Count == 0)
        {
          Console.WriteLine("\nNo accounts");
          return;
        }

        Console.WriteLine("\n********ALL ACCOUNTS********");
        foreach (Account account in allAccounts)
        {
          Console.WriteLine("Account Number: " + account.AccountNumber);

          Customer customer = customersBusinessLogicLayer.GetCustomersByCondition(cust => cust.CustomerID == account.CustomerID).FirstOrDefault();
          if (customer != null)
          {
            Console.WriteLine("Customer Code: " + customer.CustomerCode);
            Console.WriteLine("Customer Name: " + customer.CustomerName);
          }
          Console.WriteLine("Balance: " + account.Balance + "\n");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.GetType());
      }
    }

    internal static void UpdateAccount()
    {
      try
      {
        IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();

        if (accountsBusinessLogicLayer.GetAccounts().Count <= 0)
        {
          Console.WriteLine("\nNo accounts exist");
          return;
        }

        ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

        Console.WriteLine("\n********EDIT ACCOUNT********");
        ViewAccounts();

        Console.Write("Enter the Account Number that you want to edit: ");
        long accountNoToEdit;
        while (!long.TryParse(Console.ReadLine(), out accountNoToEdit))
        {
          Console.Write("Enter the Account Number that you want to edit: ");
        }

        Account filteredAccount = accountsBusinessLogicLayer.GetAccountsByCondition(acc => acc.AccountNumber == accountNoToEdit).FirstOrDefault();

        if (filteredAccount == null)
        {
          Console.WriteLine("\nInvalid Account Number.");
          return;
        }

        Console.Write("Balance: ");
        filteredAccount.Balance = long.Parse(Console.ReadLine());

        bool isUpdated = accountsBusinessLogicLayer.UpdateAccount(filteredAccount);

        if (isUpdated)
        {
          Console.WriteLine("\nAccount Updated.");
        }
        else
        {
          Console.WriteLine("\nAccount not updated.");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.GetType());
      }
    }

    internal static void DeleteAccount()
    {
      try
      {
        IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();

        if (accountsBusinessLogicLayer.GetAccounts().Count <= 0)
        {
          Console.WriteLine("\nNo accounts exist");
          return;
        }

        Console.WriteLine("\n********DELETE ACCOUNT********");
        ViewAccounts();

        Console.Write("Enter the Account Number that you want to delete: ");
        long accountNoToDelete;
        while (!long.TryParse(Console.ReadLine(), out accountNoToDelete))
        {
          Console.Write("Enter the Account Number that you want to delete: ");
        }

        Account existingAccount = accountsBusinessLogicLayer.GetAccountsByCondition(acc => acc.AccountNumber == accountNoToDelete).FirstOrDefault();
        if (existingAccount == null)
        {
          Console.WriteLine("\nInvalid Account Number.");
          return;
        }

        bool isDeleted = accountsBusinessLogicLayer.DeleteAccount(existingAccount.AccountID);

        if (isDeleted)
        {
          Console.WriteLine("\nAccount Deleted.");
        }
        else
        {
          Console.WriteLine("\nAccount not deleted");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.GetType());
      }
    }

    internal static void AccountStatement()
    {
      ITransactionsBusinessLogicLayer transactionsBusinessLogicLayer = new TransactionBusinessLogicLayer();

      if (transactionsBusinessLogicLayer.GetTransactions().Count <= 0)
      {
        Console.WriteLine("\nNo transferred funds");
        return;
      }

      ViewAccounts();

      IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();

      Console.Write("Enter the Account Number that you want to view: ");
      long accountNoToView;
      while (!long.TryParse(Console.ReadLine(), out accountNoToView))
      {
        Console.Write("Enter the Account Number that you want to view: ");
      }
      Account existingAccount = accountsBusinessLogicLayer.GetAccountsByCondition(acc => acc.AccountNumber == accountNoToView).FirstOrDefault();
      if (existingAccount == null)
      {
        Console.WriteLine("\nInvalid Account Number.");
        return;
      }

      List<Transaction> transactionDebit = transactionsBusinessLogicLayer.GetTransactionsByCondition(trans => trans.SourceAccNum == accountNoToView);

      Console.WriteLine("\nDebit Transactions:");
      if (transactionDebit.Count == 0) Console.WriteLine("No debit transactions");
      foreach (Transaction transaction in transactionDebit)
      {
        Console.WriteLine("Transaction Date: " + transaction.TransactionDate);
        Console.WriteLine("Source Account Number: " + transaction.SourceAccNum);
        Console.WriteLine("Destination Account Number: " + transaction.DestinationAccNum);
        Console.WriteLine("Transaction Amount: " + transaction.Amount);
      }

      List<Transaction> transactionCredit = transactionsBusinessLogicLayer.GetTransactionsByCondition(trans => trans.DestinationAccNum == accountNoToView);

      Console.WriteLine("\nCredit Transactions:");
      if (transactionCredit.Count == 0) Console.WriteLine("No credit transactions");
      foreach (Transaction transaction in transactionCredit)
      {
        Console.WriteLine("Transaction Date: " + transaction.TransactionDate);
        Console.WriteLine("Source Account Number: " + transaction.SourceAccNum);
        Console.WriteLine("Destination Account Number: " + transaction.DestinationAccNum);
        Console.WriteLine("Transaction Amount: " + transaction.Amount);
      }
    }
  }
}
