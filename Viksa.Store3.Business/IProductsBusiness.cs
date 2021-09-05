using System.Collections.Generic;
using Viksa.Store3.Models.Products;

namespace Viksa.Store3.Business
{
    public interface IProductsBusiness
    {
        IEnumerable<Product> GetAll();

        IEnumerable<Product> Get(IEnumerable<int> ids);
        IEnumerable<ProductPrice> GetPrices(IEnumerable<int> productIds);
    }
}
