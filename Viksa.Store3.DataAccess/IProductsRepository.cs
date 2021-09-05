using System.Collections.Generic;
using Viksa.Store3.Models.Products;

namespace Viksa.Store3.DataAccess
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> Get(IEnumerable<int> ids);
    }
}
