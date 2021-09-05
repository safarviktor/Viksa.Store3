using Viksa.Store3.Models;
using Viksa.Store3.Models.Order;

namespace Viksa.Store3.Business
{
    public interface IAgreementsBusiness 
    {
        IAgreement Get(int id);
        Order ApplyAgreement(Order order);
    }
}
