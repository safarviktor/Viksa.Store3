namespace Viksa.Store3.Models
{
    public class AgreementVolumeDiscount : AbstractAgreement, IAgreement
    {
        public AgreementType Type => AgreementType.Volume;
        
        public int MinimumNumberOfUnits { get; set; }
    }
}
