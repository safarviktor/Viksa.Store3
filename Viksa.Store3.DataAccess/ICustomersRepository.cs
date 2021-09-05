using System.Collections.Generic;
using Viksa.Store3.Models.Customers;

namespace Viksa.Store3.DataAccess
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> GetAll();
        string GetName(int id);
    }
}
