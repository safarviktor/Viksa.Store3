using System.Collections.Generic;
using Viksa.Store3.Models.Order;

namespace Viksa.Store3.DataAccess
{
    public interface IOrdersRepository
    {
        int SaveOrder(Order order);
        Order Get(int id);
        IEnumerable<Order> GetAll();
    }
}
