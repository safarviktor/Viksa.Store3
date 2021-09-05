namespace Viksa.Store3.Models
{
    public class AgreementSpecialDeal : AbstractAgreement, IAgreement
    {
        public AgreementType Type => AgreementType.SpecialDeal;

        public string Reason { get; set; }
    }
}
