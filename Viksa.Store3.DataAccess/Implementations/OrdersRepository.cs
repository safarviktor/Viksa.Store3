using System.Collections.Generic;
using System.Linq;
using Viksa.Store3.Models.Order;

namespace Viksa.Store3.DataAccess.Implementations
{
    internal class OrdersRepository : IOrdersRepository
    {
        private List<Order> _orders = new List<Order>();

        public Order Get(int id)
        {
            return _orders.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orders;
        }

        public int SaveOrder(Order order)
        {
            var newId = _orders.Count + 1;
            order.Id = newId;
            _orders.Add(order);
            return newId;
        }
    }
}
