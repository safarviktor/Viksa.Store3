namespace Viksa.Store3.Models.Order
{
    public class OrderLine
    {
        public int ProductId { get; set; }
        public decimal OriginalPricePerUnit { get; set; }
        public decimal FinalPricePerUnit { get; set; }
        public int NumberOfUnits { get; set; }
    }
}
