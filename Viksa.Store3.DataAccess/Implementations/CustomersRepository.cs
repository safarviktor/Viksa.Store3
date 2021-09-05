using System.Collections.Generic;
using System.Linq;
using Viksa.Store3.Models.Customers;

namespace Viksa.Store3.DataAccess.Implementations
{
    internal class CustomersRepository : ICustomersRepository
    {
        private readonly List<Customer> _customers = new List<Customer>()
        {
            new Customer() { Id = 1, Name = "ABC AS" },
            new Customer() { Id = 2, Name = "Diddliby AS" },
            new Customer() { Id = 3, Name = "First World News AS" },
            new Customer() { Id = 4, Name = "Fun 1000"},
        };

        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        public string GetName(int id)
        {
            return _customers.FirstOrDefault(x => x.Id == id)?.Name;
        }
    }
}
