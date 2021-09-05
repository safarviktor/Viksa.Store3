using System.Collections.Generic;
using System.Linq;
using Viksa.Store3.DataAccess;
using Viksa.Store3.Models.Order;

namespace Viksa.Store3.Business.Implementations
{
    internal class OrdersBusiness : IOrdersBusiness
    {
        private readonly IOrdersRepository _ordersRepository;        
        private readonly IProductPricesRepository _productPricessRepository;        
        private readonly IAgreementsBusiness _agreementsBusiness;

        public OrdersBusiness(IOrdersRepository ordersRepository, IProductPricesRepository productPricessRepository, IAgreementsBusiness agreementsBusiness)
        {
            _ordersRepository = ordersRepository;
            _productPricessRepository = productPricessRepository;
            _agreementsBusiness = agreementsBusiness;
        }

        public Order Get(int id)
        {
            return _ordersRepository.Get(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _ordersRepository.GetAll();
        }

        public int CreateNew(CreateNewOrderCommand command)
        {
            var productPrices = _productPricessRepository.GetPrices(command.OrderLines.Select(x => x.ProductId));

            var newOrder = new Order()
            {
                CustomerId = command.CustomerId,
                FullFillmentDate = command.FullFillmentDate,
                OrderLines = new List<OrderLine>()
            };

            foreach (var line in command.OrderLines)
            {
                var productPrice = productPrices.FirstOrDefault(pp => pp.ProductId == line.ProductId).Price;
                newOrder.OrderLines.Add(new OrderLine()
                {
                    ProductId = line.ProductId,
                    NumberOfUnits = line.NumberOfUnits,
                    OriginalPricePerUnit = productPrice,
                    FinalPricePerUnit = productPrice
                });
            }
                        
            newOrder = _agreementsBusiness.ApplyAgreement(newOrder);

            return _ordersRepository.SaveOrder(newOrder);
        }
    }
}
