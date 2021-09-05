using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Viksa.Store3.Business;
using Viksa.Store3.Models.Order;
using Viksa.Store3.Web.Models.Orders;

namespace Viksa.Store3.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ICustomersBusiness _customersBusiness;
        private readonly IProductsBusiness _productsBusiness;        
        private readonly IOrdersBusiness _ordersBusiness;
        private readonly IAgreementsBusiness _agreementsBusiness;

        private readonly IEnumerable<SelectListItem> _availableProducts;

        public OrdersController(ICustomersBusiness customersBusiness, IProductsBusiness productsBusiness, IOrdersBusiness ordersBusiness, IAgreementsBusiness agreementsBusiness)
        {
            _customersBusiness = customersBusiness;
            _productsBusiness = productsBusiness;
            _availableProducts = _productsBusiness.GetAll().Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            _ordersBusiness = ordersBusiness;
            _agreementsBusiness = agreementsBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allOrders = _ordersBusiness.GetAll();
            var products = _productsBusiness.Get(allOrders.SelectMany(x => x.OrderLines).Select(x => x.ProductId));

            var model = new ViewOrderListModel();
            model.Orders = allOrders.Select(order => new ViewOrderModel()
            {
                Id = order.Id,
                CustomerName = _customersBusiness.GetName(order.CustomerId),
                FullFillmentDate = order.FullFillmentDate       ,
                OrderLines = order.OrderLines.Select(line => new ViewOrderLineModel()
                {
                    ProductName = products.First(p => p.Id == line.ProductId).Name,
                    NumberOfUnits = line.NumberOfUnits,
                    OriginalPricePerUnit = line.OriginalPricePerUnit,
                    FinalPricePerUnit = line.FinalPricePerUnit
                }).ToList()
            }).ToList();

            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Customers = _customersBusiness.GetAll().Select(x => new SelectListItem(x.Name, x.Id.ToString()));            

            var vm = new NewOrderModel()
            {
                FullFillmentDate = System.DateTime.Now
            };
            
            return View(vm);
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            var order = _ordersBusiness.Get(id);
            var viewOrderModel = new ViewOrderModel();

            if (order != null)
            {
                var selectedProducts = _productsBusiness.Get(order.OrderLines.Select(x => x.ProductId));

                viewOrderModel.Id = order.Id;
                viewOrderModel.CustomerName = _customersBusiness.GetName(order.CustomerId);
                viewOrderModel.FullFillmentDate = order.FullFillmentDate;
                if (order.AppliedAgreementId.HasValue)
                {
                    viewOrderModel.AssignedAgreementName = _agreementsBusiness.Get(order.AppliedAgreementId.Value).Name;
                }

                viewOrderModel.OrderLines = order.OrderLines.Select(line => new ViewOrderLineModel()
                {
                    ProductName = selectedProducts.First(p => p.Id == line.ProductId).Name,
                    NumberOfUnits = line.NumberOfUnits,
                    OriginalPricePerUnit = line.OriginalPricePerUnit,
                    FinalPricePerUnit = line.FinalPricePerUnit
                }).ToList();
            }

            return View(viewOrderModel);
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            var command = new CreateNewOrderCommand();
            command.CustomerId = Convert.ToInt32(collection[nameof(NewOrderModel.CustomerId)]);
            command.FullFillmentDate = Convert.ToDateTime(collection[nameof(NewOrderModel.FullFillmentDate)]);
            command.OrderLines = GetOrderLinesFromForm(collection);
            var orderId = _ordersBusiness.CreateNew(command);

            return RedirectToAction("View", new { id = orderId });
        }

        private List<NewOrderLine> GetOrderLinesFromForm(IFormCollection collection)
        {
            var productIds = Convert.ToString(collection[nameof(NewOrderLineModel.ProductId)]).Split(",").Select(x => Convert.ToInt32(x)).ToList();
            var units = Convert.ToString(collection[nameof(NewOrderLineModel.ProductId)]).Split(",").Select(x => Convert.ToInt32(x)).ToList();
            
            var results = new List<NewOrderLine>();

            for(int i = 0; i < productIds.Count; i++)
            {
                results.Add(new NewOrderLine()
                {
                    ProductId = productIds[i],
                    NumberOfUnits = units[i]
                });
            }

            return results;
        }

        public IActionResult GetNewOrderLine()
        {
            ViewBag.Products = _availableProducts;
            var model = new NewOrderLineModel();
            return PartialView("_newOrderLine", model);
        }
    }
}
