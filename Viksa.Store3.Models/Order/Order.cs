using System;
using System.Collections.Generic;

namespace Viksa.Store3.Models.Order
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<OrderLine> OrderLines { get; set; }                
        public DateTime FullFillmentDate { get; set; }
        public int? AppliedAgreementId { get; set; }
    }
}
