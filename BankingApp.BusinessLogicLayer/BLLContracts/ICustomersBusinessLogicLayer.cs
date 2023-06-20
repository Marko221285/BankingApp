using System;
using System.Collections.Generic;
using BankingApp.Entities;

namespace BankingApp.BusinessLogicLayer.BLLContracts
{
  public interface ICustomersBusinessLogicLayer
  {
    List<Customer> GetCustomers();

    List<Customer> GetCustomersByCondition(Predicate<Customer> predicate);

    Guid AddCustomer(Customer customer);

    bool UpdateCustomer(Customer customer);

    bool DeleteCustomer(Guid customerID);
  }
}
