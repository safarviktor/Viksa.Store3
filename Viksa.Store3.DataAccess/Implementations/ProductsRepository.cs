using System.Collections.Generic;
using System.Linq;
using Viksa.Store3.Models.Products;

namespace Viksa.Store3.DataAccess.Implementations
{
    internal class ProductsRepository : IProductsRepository
    {
        private readonly List<Product> _products = new List<Product>()
        {
            new Product() { Id = 1, Name = "Chair" },
            new Product() { Id = 2, Name = "Sofa" },
            new Product() { Id = 3, Name = "Table" },
            new Product() { Id = 4, Name = "Shiny table"},
        };

        public IEnumerable<Product> Get(IEnumerable<int> ids)
        {
            return _products.Where(x => ids.Contains(x.Id));
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
    }
}
