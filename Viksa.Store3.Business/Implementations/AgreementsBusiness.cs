using System;
using Viksa.Store3.DataAccess;
using Viksa.Store3.Models;
using Viksa.Store3.Models.Order;

namespace Viksa.Store3.Business.Implementations
{
    public class AgreementsBusiness : IAgreementsBusiness
    {
        private readonly IAgreementsRepository _agreementsRepository;

        public AgreementsBusiness(IAgreementsRepository agreementsRepository)
        {
            _agreementsRepository = agreementsRepository;
        }

        public IAgreement Get(int id)
        {
            return _agreementsRepository.Get(id);
        }

        public Order ApplyAgreement(Order order)
        {
            var agreement = _agreementsRepository.GetAgreementForCustomer(order.CustomerId);

            if (agreement == null)
            {
                return order;
            }    

            order.AppliedAgreementId = agreement.Id;

            switch (agreement.Type)
            {
                case AgreementType.Volume:
                    return ApplyVolumeAgreement(order, agreement as AgreementVolumeDiscount);
                case AgreementType.TimeOfYear:
                    return ApplyTimeOfYearAgreement(order, agreement as AgreementTimeOfYear);
                case AgreementType.SpecialDeal:
                    return ApplySpecialDealAgreement(order, agreement as AgreementSpecialDeal);
                default:
                    throw new NotImplementedException($"{agreement.Type} not implemented");
            }
        }        

        private Order ApplySpecialDealAgreement(Order order, AgreementSpecialDeal agreementSpecialDeal)
        {
            foreach (var line in order.OrderLines)
            {
                line.FinalPricePerUnit = line.OriginalPricePerUnit * (100 - agreementSpecialDeal.DiscountPercent) / 100;
            }

            return order;
        }

        private Order ApplyTimeOfYearAgreement(Order order, AgreementTimeOfYear agreementTimeOfYear)
        {
            if (OrderDateWithinPeriod(order.FullFillmentDate, agreementTimeOfYear))
            {
                foreach (var line in order.OrderLines)
                {
                    line.FinalPricePerUnit = line.OriginalPricePerUnit * (100 - agreementTimeOfYear.DiscountPercent) / 100;
                }
            }

            return order;
        }

        private bool OrderDateWithinPeriod(DateTime fullFillmentDate, AgreementTimeOfYear agreementTimeOfYear)
        {
            // if this happens every year, then we need to find the start and end dates relevant to the order
            var applicableStart = new DateTime(fullFillmentDate.Year, agreementTimeOfYear.StartDate.Month, agreementTimeOfYear.StartDate.Day);
            var applicableEnd = new DateTime(fullFillmentDate.Year, agreementTimeOfYear.EndDate.Month, agreementTimeOfYear.EndDate.Day);
            return fullFillmentDate >= applicableStart && fullFillmentDate <= applicableEnd;
        }

        private Order ApplyVolumeAgreement(Order order, AgreementVolumeDiscount agreementVolumeDiscount)
        {
            foreach (var line in order.OrderLines)
            {
                if (line.NumberOfUnits >= agreementVolumeDiscount.MinimumNumberOfUnits)
                {
                    line.FinalPricePerUnit = line.OriginalPricePerUnit * (100 - agreementVolumeDiscount.DiscountPercent) / 100;
                }
            }

            return order;
        }
    }
}
