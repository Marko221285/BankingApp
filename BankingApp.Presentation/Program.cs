namespace BankingApp.Presentation
{
  class Program
  {
    static void Main()
    {
      System.Console.WriteLine("**********Marko Bank**********");
      System.Console.WriteLine("::Login Page::");

      string userName, password = null;

      System.Console.Write("Username: ");
      userName = System.Console.ReadLine();

      if (userName != "")
      {
        System.Console.Write("Password: ");
        password = System.Console.ReadLine();
      }

      if (userName == "system" && password == "manager")
      {
        int mainMenuChoice;
        do
        {
          System.Console.WriteLine("\n:::Main menu:::");
          System.Console.WriteLine("1.Customers");
          System.Console.WriteLine("2.Accounts");
          System.Console.WriteLine("3.Funds Transfer");
          System.Console.WriteLine("4.Account Statement");
          System.Console.WriteLine("0.Exit");

          System.Console.Write("Enter Choice:");
          mainMenuChoice = int.Parse(System.Console.ReadLine());

          switch (mainMenuChoice)
          {
            case 1: CustomersMenu(); break;
            case 2: AccountsMenu(); break;
            case 3: FundsTransferMenu(); break;
            case 4: AccountStatementMenu(); break;
          }
        } while (mainMenuChoice != 0);
      }
      else
      {
        System.Console.WriteLine("Invalid username or password");
      }
      System.Console.WriteLine("Thank you! Visit us again!");
      System.Console.ReadKey();
    }

    static void CustomersMenu()
    {
      int customerMenuChoice;
      do
      {
        System.Console.WriteLine("\n:::Customers menu:::");
        System.Console.WriteLine("1.Add Customer");
        System.Console.WriteLine("2.Delete Customer");
        System.Console.WriteLine("3.Update Customer");
        System.Console.WriteLine("4.Search Customer");
        System.Console.WriteLine("5.View Customers");
        System.Console.WriteLine("0.Back to Main Menu");

        System.Console.Write("Enter choice:");
        customerMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());

        switch (customerMenuChoice)
        {
          case 1: CustomersPresentation.AddCustomer(); break;
          case 2: CustomersPresentation.DeleteCustomer(); break;
          case 3: CustomersPresentation.UpdateCustomer(); break;
          case 4: CustomersPresentation.SearchCustomer(); break;
          case 5: CustomersPresentation.ViewCustomers(); break;
        }

      } while (customerMenuChoice != 0);
    }

    static void AccountsMenu()
    {
      int accountsMenuChoice;
      do
      {
        System.Console.WriteLine("\n:::Accounts menu:::");
        System.Console.WriteLine("1.Add Account");
        System.Console.WriteLine("2.Delete Account");
        System.Console.WriteLine("3.Update Account");
        System.Console.WriteLine("4.View Accounts");
        System.Console.WriteLine("0.Back to Main Menu");

        System.Console.Write("Enter choice:");
        accountsMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());

        switch (accountsMenuChoice)
        {
          case 1: AccountsPresentation.AddAccount(); break;
          case 2: AccountsPresentation.DeleteAccount(); break;
          case 3: AccountsPresentation.UpdateAccount(); break;
          case 4: AccountsPresentation.ViewAccounts(); break;
        }

      } while (accountsMenuChoice != 0);
    }

    static void FundsTransferMenu()
    {
      FundsTransferPresentation.FundsTransfer();
    }

    static void AccountStatementMenu()
    {
      AccountsPresentation.AccountStatement();
    }
  }
}
