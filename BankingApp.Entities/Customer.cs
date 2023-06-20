using System;
using BankingApp.Entities.Contracts;
using BankingApp.Exceptions;

namespace BankingApp.Entities
{
  public class Customer : ICustomer, ICloneable
  {
    #region Private Fields
    private Guid _customerID;
    private long _customerCode;
    private string _customerName;
    private string _address;
    private string _landmark;
    private string _city;
    private string _country;
    private string _mobile;
    #endregion

    #region Public Properties
    public Guid CustomerID { get => _customerID; set => _customerID = value; }

    public long CustomerCode
    {
      get => _customerCode;
      set
      {
        if (value > 0)
        {
          _customerCode = value;
        }
        else
        {
          throw new CustomerException("Customer code should be positive only.");
        }
      }
    }

    public string CustomerName
    {
      get => _customerName;
      set
      {
        if (value.Length <= 40 && string.IsNullOrEmpty(value) == false)
        {
          _customerName = value;
        }
        else
        {
          throw new CustomerException("\nCustomer name should not be null and should be less than 40 characters long.");
        }
      }
    }

    public string Address { get => _address; set => _address = value; }

    public string Landmark { get => _landmark; set => _landmark = value; }

    public string City { get => _city; set => _city = value; }

    public string Country { get => _country; set => _country = value; }

    public string Mobile
    {
      get => _mobile;
      set
      {
        if (value.Length == 10)
        {
          _mobile = value;
        }
        else
        {
          throw new CustomerException("\nMobile number should be a 10-digit number.");
        }
      }
    }
    #endregion

    #region Methods
    public object Clone()
    {
      return new Customer() { CustomerID = this.CustomerID, CustomerCode = this.CustomerCode, CustomerName = this.CustomerName, Address = this.Address, Landmark = this.Landmark, City = this.City, Country = this.Country, Mobile = this.Mobile };
    }
    #endregion
  }
}
