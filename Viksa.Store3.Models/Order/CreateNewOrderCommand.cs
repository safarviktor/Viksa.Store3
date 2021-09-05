using System;
using System.Collections.Generic;

namespace Viksa.Store3.Models.Order
{
    public class CreateNewOrderCommand
    {
        public int CustomerId { get; set; }
        public List<NewOrderLine> OrderLines { get; set; }
        public DateTime FullFillmentDate { get; set; }
    }
}
