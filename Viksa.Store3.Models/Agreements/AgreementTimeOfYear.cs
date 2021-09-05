using System;

namespace Viksa.Store3.Models
{
    public class AgreementTimeOfYear : AbstractAgreement, IAgreement
    {
        public AgreementType Type => AgreementType.TimeOfYear;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
