namespace Viksa.Store3.Models
{
    public abstract class AbstractAgreement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}
