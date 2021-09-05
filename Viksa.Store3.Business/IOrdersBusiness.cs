using System.Collections.Generic;
using Viksa.Store3.Models.Order;

namespace Viksa.Store3.Business
{
    public interface IOrdersBusiness
    {
        int CreateNew(CreateNewOrderCommand command);
        public Order Get(int id);
        IEnumerable<Order> GetAll();
    }
}
