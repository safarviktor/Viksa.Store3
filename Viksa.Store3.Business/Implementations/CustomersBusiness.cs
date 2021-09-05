using System.Collections.Generic;
using Viksa.Store3.DataAccess;
using Viksa.Store3.Models.Customers;

namespace Viksa.Store3.Business.Implementations
{
    internal class CustomersBusiness : ICustomersBusiness
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersBusiness(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customersRepository.GetAll();
        }

        public string GetName(int id)
        {
            return _customersRepository.GetName(id);
        }
    }
}
