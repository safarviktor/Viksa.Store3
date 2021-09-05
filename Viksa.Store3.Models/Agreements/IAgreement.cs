using System;

namespace Viksa.Store3.Models
{
    public interface IAgreement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal DiscountPercent { get; set; }
        public AgreementType Type { get;}
    }
}
