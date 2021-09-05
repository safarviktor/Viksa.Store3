using System.Collections.Generic;
using Viksa.Store3.Models.Products;

namespace Viksa.Store3.DataAccess
{
    public interface IProductPricesRepository
    {
        IEnumerable<ProductPrice> GetPrices(IEnumerable<int> productIds);
    }
}
