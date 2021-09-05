using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Viksa.Store3.Web.Models.Orders
{
    public class NewOrderModel
    {
        public int CustomerId { get; set; }
        [DataType(DataType.Date)]
        public DateTime FullFillmentDate { get; set; }
        public List<NewOrderLineModel> OrderLines { get; set; }
    }
}
