using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viksa.Store3.Models.Products;

namespace Viksa.Store3.DataAccess.Implementations
{
    internal class ProductPricesRepository : IProductPricesRepository
    {
        private readonly List<ProductPrice> _productPrices = new List<ProductPrice>()
        {
            new ProductPrice() { ProductId = 1, Price = 1000 },
            new ProductPrice() { ProductId = 2, Price = 5.5m },
            new ProductPrice() { ProductId = 3, Price = 122 },
            new ProductPrice() { ProductId = 4, Price = 89 },
        };

        public IEnumerable<ProductPrice> GetPrices(IEnumerable<int> productIds)
        {
            return _productPrices.Where(x => productIds.Contains(x.ProductId)).ToList();
        }
    }
}
