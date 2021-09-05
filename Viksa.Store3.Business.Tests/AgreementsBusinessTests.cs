using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Viksa.Store3.Business.Implementations;
using Viksa.Store3.DataAccess;
using Viksa.Store3.Models;
using Viksa.Store3.Models.Order;

namespace Viksa.Store3.Business.Tests
{
    public abstract class AgreementsBusinessTests
    {
        protected IAgreementsBusiness Undertest;
        protected Mock<IAgreementsRepository> AgreementsRepositoryMock = new Mock<IAgreementsRepository>();
        protected IAgreement Agreement;

        public AgreementsBusinessTests()
        {
            AgreementsRepositoryMock.Setup(x => x.GetAgreementForCustomer(1)).Returns(MockAgreementForCustomer);

            Undertest = new AgreementsBusiness(AgreementsRepositoryMock.Object);
        }

        private IAgreement MockAgreementForCustomer()
        {
            return Agreement;
        }
    }

    [TestClass]
    public class ApplyAgreementTests : AgreementsBusinessTests
    {
        private Order _order = new Order()
        {
            CustomerId = 1,
            FullFillmentDate = new DateTime(2020, 10, 30),
            OrderLines = new List<OrderLine>()
            {
                new OrderLine()
                {
                    ProductId = 1,
                    OriginalPricePerUnit = 100,
                    FinalPricePerUnit = 100,
                    NumberOfUnits = 1
                },
                new OrderLine()
                {
                    ProductId = 2,
                    OriginalPricePerUnit = 300,
                    FinalPricePerUnit = 300,
                    NumberOfUnits = 1
                }
            }
        };

        [TestMethod]
        public void WhenNoAgreement_ThenFinalPriceEqualsOriginalPrice()
        {
            var result = Undertest.ApplyAgreement(_order);

            Assert.AreEqual(result.OrderLines.First().FinalPricePerUnit, 100);
        }

        [TestMethod]
        public void WhenSpecialDeal50PercentAgreement_ThenFinalPriceEqualsHalfOfOriginalPriceOnEachProduct()
        {
            Agreement = new AgreementSpecialDeal() 
            { 
                Id = 10,
                DiscountPercent = 50,
                Name = "50% off",
                Reason = "For fun"
            };

            var result = Undertest.ApplyAgreement(_order);

            Assert.AreEqual(result.OrderLines.First().FinalPricePerUnit, 50);
            Assert.AreEqual(result.OrderLines.Skip(1).Take(1).First().FinalPricePerUnit, 150);
        }
    }
}
