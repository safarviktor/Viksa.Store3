using System.Collections.Generic;
using Viksa.Store3.Models.Customers;

namespace Viksa.Store3.Business
{
    public interface ICustomersBusiness
    {
        IEnumerable<Customer> GetAll();
        string GetName(int id);
    }
}
