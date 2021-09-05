using System.Collections.Generic;
using Viksa.Store3.DataAccess;
using Viksa.Store3.Models.Products;

namespace Viksa.Store3.Business.Implementations
{
    internal class ProductsBusiness : IProductsBusiness
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IProductPricesRepository _productPricesRepository;
        public ProductsBusiness(IProductsRepository productsRepository, IProductPricesRepository productPricesRepository)
        {
            _productsRepository = productsRepository;
            _productPricesRepository = productPricesRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productsRepository.GetAll();
        }

        public IEnumerable<Product> Get(IEnumerable<int> ids)
        {
            return _productsRepository.Get(ids);
        }

        public IEnumerable<ProductPrice> GetPrices(IEnumerable<int> productIds)
        {
            return _productPricesRepository.GetPrices(productIds);
        }
    }
}
