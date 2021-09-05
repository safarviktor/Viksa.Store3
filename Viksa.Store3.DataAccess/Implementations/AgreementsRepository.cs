using System;
using System.Collections.Generic;
using System.Linq;
using Viksa.Store3.Models;

namespace Viksa.Store3.DataAccess.Implementations
{
    internal class AgreementsRepository : IAgreementsRepository
    {
        private List<IAgreement> _agreements = new List<IAgreement>()
        {
            new AgreementSpecialDeal()
            {
                Id = 101,
                Name = "10% off",
                DiscountPercent = 10,
                Reason = "Customer is really nice."
            },
            new AgreementTimeOfYear()
            {
                Id = 102,
                Name = "Back to school special - 30% off",
                DiscountPercent = 30,
                StartDate = new DateTime(2000, 9, 1),
                EndDate = new DateTime(2000, 9, 30)
            },
            new AgreementVolumeDiscount()
            {
                Id = 103,
                Name = "50% off for 100 products or more",
                DiscountPercent = 50,
                MinimumNumberOfUnits = 100
            }
        };

        private Dictionary<int, int> _customerAgreements = new Dictionary<int, int>()
        {
            { 1, 101 },
            { 2, 102 },
            { 3, 103 }
        };

        public IAgreement GetAgreementForCustomer(int customerId)
        {
            if (_customerAgreements.ContainsKey(customerId))
            {
                var agreementId = _customerAgreements[customerId];                
                return _agreements.FirstOrDefault(x => x.Id == agreementId);
            }

            return null;
        }

        public IAgreement Get(int id)
        {
            return _agreements.FirstOrDefault(x => x.Id == id);
        }
    }
}
