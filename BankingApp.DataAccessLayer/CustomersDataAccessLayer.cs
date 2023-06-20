using System;
using System.Collections.Generic;
using BankingApp.Entities;
using BankingApp.DataAccessLayer.DALContracts;
using BankingApp.Exceptions;

namespace BankingApp.DataAccessLayer
{
  public class CustomersDataAccessLayer : ICustomersDataAccessLayer
  {
    #region Fields
    private static List<Customer> _customers;
    #endregion

    #region Constructors
    static CustomersDataAccessLayer()
    {
      _customers = new List<Customer>();
    }
    #endregion

    #region Properties
    private static List<Customer> Customers
    {
      set => _customers = value;
      get => _customers;
    }
    #endregion

    #region Methods
    public List<Customer> GetCustomers()
    {
      try
      {
        List<Customer> customersList = new List<Customer>();

        Customers.ForEach(item => customersList.Add(item.Clone() as Customer));
        return customersList;
      }
      catch (CustomerException)
      {
        throw;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
    {
      try
      {
        List<Customer> customersList = new List<Customer>();

        List<Customer> filteredCustomers = Customers.FindAll(predicate);
        filteredCustomers.ForEach(item => customersList.Add(item.Clone() as Customer));
        return customersList;
      }
      catch (CustomerException)
      {
        throw;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public Guid AddCustomer(Customer customer)
    {
      try
      {
        customer.CustomerID = Guid.NewGuid();

        Customers.Add(customer);

        return customer.CustomerID;
      }
      catch (CustomerException)
      {
        throw;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public bool UpdateCustomer(Customer customer)
    {
      try
      {
        Customer existingCustomer = Customers.Find(item => item.CustomerID == customer.CustomerID);

        if (existingCustomer != null)
        {
          existingCustomer.CustomerCode = customer.CustomerCode;
          existingCustomer.CustomerName = customer.CustomerName;
          existingCustomer.Address = customer.Address;
          existingCustomer.Landmark = customer.Landmark;
          existingCustomer.City = customer.City;
          existingCustomer.Country = customer.Country;
          existingCustomer.Mobile = customer.Mobile;

          return true;
        }
        else
        {
          return false;
        }
      }
      catch (CustomerException)
      {
        throw;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public bool DeleteCustomer(Guid customerID)
    {
      try
      {
        if (Customers.RemoveAll(item => item.CustomerID == customerID) > 0)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (CustomerException)
      {
        throw;
      }
      catch (Exception)
      {

        throw;
      }
    }
    #endregion
  }
}
