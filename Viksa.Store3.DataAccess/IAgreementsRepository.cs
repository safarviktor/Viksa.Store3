using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viksa.Store3.Models;

namespace Viksa.Store3.DataAccess
{
    public interface IAgreementsRepository
    {
        IAgreement GetAgreementForCustomer(int customerId);
        IAgreement Get(int id);
    }
}
