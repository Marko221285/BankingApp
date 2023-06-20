using System;
using System.Collections.Generic;
using BankingApp.Entities;

namespace BankingApp.DataAccessLayer.DALContracts
{
  public interface ICustomersDataAccessLayer
  {
    List<Customer> GetCustomers();

    List<Customer> GetCustomersByCondition(Predicate<Customer> predicate);

    Guid AddCustomer(Customer customer);

    bool UpdateCustomer(Customer customer);

    bool DeleteCustomer(Guid customerID);
  }
}
