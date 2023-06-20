using System;
using System.Collections.Generic;
using System.Linq;
using BankingApp.Entities;
using BankingApp.BusinessLogicLayer;
using BankingApp.BusinessLogicLayer.BLLContracts;

namespace BankingApp.Presentation
{
  static class CustomersPresentation
  {
    internal static void AddCustomer()
    {
      try
      {
        Customer customer = new Customer();

        Console.WriteLine("\n********ADD CUSTOMER********");
        Console.Write("Customer Name: ");
        customer.CustomerName = Console.ReadLine();
        Console.Write("Address: ");
        customer.Address = Console.ReadLine();
        Console.Write("Landmark: ");
        customer.Landmark = Console.ReadLine();
        Console.Write("City: ");
        customer.City = Console.ReadLine();
        Console.Write("Country: ");
        customer.Country = Console.ReadLine();
        Console.Write("Mobile: ");
        customer.Mobile = Console.ReadLine();

        ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();
        Guid newGuid = customersBusinessLogicLayer.AddCustomer(customer);

        List<Customer> existingCustomer = customersBusinessLogicLayer.GetCustomersByCondition(cust => cust.CustomerID == newGuid);
        if (existingCustomer.Count >= 1)
        {
          Console.WriteLine("\n" + existingCustomer[0].CustomerCode);
          Console.WriteLine("Customer added.");
        }
        else
        {
          Console.WriteLine("\nCustomer not added.");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.GetType());
      }
    }

    internal static void ViewCustomers()
    {
      try
      {
        ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

        if (customersBusinessLogicLayer.GetCustomers().Count <= 0)
        {
          Console.WriteLine("\nNo customers exist");
          return;
        }

        List<Customer> allCustomers = customersBusinessLogicLayer.GetCustomers();

        Console.WriteLine("\n********ALL CUSTOMERS********");
        foreach (Customer customer in allCustomers)
        {
          Console.WriteLine("CustomerCode: " + customer.CustomerCode);
          Console.WriteLine("CustomerName: " + customer.CustomerName);
          Console.WriteLine("Address: " + customer.Address);
          Console.WriteLine("Landmark: " + customer.Landmark);
          Console.WriteLine("City: " + customer.City);
          Console.WriteLine("Country: " + customer.Country);
          Console.WriteLine("Mobile: " + customer.Mobile);
          Console.WriteLine();
        }
      }

      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.GetType());
      }
    }

    internal static void UpdateCustomer()
    {
      try
      {
        ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

        if (customersBusinessLogicLayer.GetCustomers().Count <= 0)
        {
          Console.WriteLine("\nNo customers exist");
          return;
        }

        Console.WriteLine("\n********EDIT CUSTOMER********");
        ViewCustomers();

        Console.Write("Enter the Customer Code that you want to edit: ");
        long customerCodeToEdit;
        while (!long.TryParse(Console.ReadLine(), out customerCodeToEdit))
        {
          Console.Write("Enter the Customer Code that you want to edit: ");
        }
        Customer existingCustomer = customersBusinessLogicLayer.GetCustomersByCondition(cust => cust.CustomerCode == customerCodeToEdit).FirstOrDefault();
        if (existingCustomer == null)
        {
          Console.WriteLine("\nInvalid Customer Code.");
          return;
        }

        Console.WriteLine("\nNEW CUSTOMER DETAILS:");
        Console.Write("Customer Name: ");
        existingCustomer.CustomerName = Console.ReadLine();
        Console.Write("Address: ");
        existingCustomer.Address = Console.ReadLine();
        Console.Write("Landmark: ");
        existingCustomer.Landmark = Console.ReadLine();
        Console.Write("City: ");
        existingCustomer.City = Console.ReadLine();
        Console.Write("Country: ");
        existingCustomer.Country = Console.ReadLine();
        Console.Write("Mobile: ");
        existingCustomer.Mobile = Console.ReadLine();

        bool isUpdated = customersBusinessLogicLayer.UpdateCustomer(existingCustomer);

        if (isUpdated)
        {
          Console.WriteLine("\nCustomer Updated.");
        }
        else
        {
          Console.WriteLine("\nCustomer not updated");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.GetType());
      }
    }

    internal static void SearchCustomer()
    {
      try
      {
        ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

        if (customersBusinessLogicLayer.GetCustomers().Count <= 0)
        {
          Console.WriteLine("\nNo customers exist");
          return;
        }

        Console.Write("\nEnter the Customer Name that you want to search for: ");
        string customerNameToSearch = Console.ReadLine();

        Customer existingCustomer = customersBusinessLogicLayer.GetCustomersByCondition(cust => string.Equals(cust.CustomerName, customerNameToSearch, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

        if (existingCustomer == null)
        {
          Console.WriteLine("\nNo such customer.");
          return;
        }

        Console.WriteLine("\n********SEARCHED CUSTOMER********");
        Console.WriteLine("CustomerCode: " + existingCustomer.CustomerCode);
        Console.WriteLine("CustomerName: " + existingCustomer.CustomerName);
        Console.WriteLine("Address: " + existingCustomer.Address);
        Console.WriteLine("Landmark: " + existingCustomer.Landmark);
        Console.WriteLine("City: " + existingCustomer.City);
        Console.WriteLine("Country: " + existingCustomer.Country);
        Console.WriteLine("Mobile: " + existingCustomer.Mobile);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.GetType());
      }
    }

    internal static void DeleteCustomer()
    {
      try
      {
        ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

        if (customersBusinessLogicLayer.GetCustomers().Count <= 0)
        {
          Console.WriteLine("\nNo customers exist");
          return;
        }

        Console.WriteLine("\n********DELETE CUSTOMER********");
        ViewCustomers();

        Console.Write("Enter the Customer Code that you want to delete: ");
        long customerCodeToDelete;
        while (!long.TryParse(Console.ReadLine(), out customerCodeToDelete))
        {
          Console.Write("Enter the Customer Code that you want to delete: ");
        }

        Customer existingCustomer = customersBusinessLogicLayer.GetCustomersByCondition(cust => cust.CustomerCode == customerCodeToDelete).FirstOrDefault();
        if (existingCustomer == null)
        {
          Console.WriteLine("\nInvalid Customer Code.");
          return;
        }

        bool isDeleted = customersBusinessLogicLayer.DeleteCustomer(existingCustomer.CustomerID);

        if (isDeleted)
        {
          Console.WriteLine("\nCustomer Deleted.");
        }
        else
        {
          Console.WriteLine("\nCustomer not deleted");
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

