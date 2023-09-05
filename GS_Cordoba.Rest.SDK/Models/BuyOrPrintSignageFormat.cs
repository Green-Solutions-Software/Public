namespace GS.Cordoba.Rest.SDK.Models
{
    public class BuyOrPrintSignageFormat : Entity
    {
        public Format Format { get; set; }
        public bool Checked { get; set; }

        public dynamic Fields;
            
    }
}
