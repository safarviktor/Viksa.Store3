namespace Viksa.Store3.Web.Models.Orders
{
    public class ViewOrderLineModel
    {
        public string ProductName { get; set; }
        public int NumberOfUnits { get; set; }
        public decimal OriginalPricePerUnit { get; set; }
        public decimal FinalPricePerUnit { get; set; }
        public decimal TotalPrice => FinalPricePerUnit * NumberOfUnits;
    }
}
