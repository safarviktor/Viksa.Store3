using System;
using System.Collections.Generic;
using System.Linq;

namespace Viksa.Store3.Web.Models.Orders
{
    public class ViewOrderModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime FullFillmentDate { get; set; }
        public List<ViewOrderLineModel> OrderLines { get; set; }
        public string AssignedAgreementName {get; set;}
        public decimal TotalPrice => OrderLines.Sum(x => x.TotalPrice);
    }
}
