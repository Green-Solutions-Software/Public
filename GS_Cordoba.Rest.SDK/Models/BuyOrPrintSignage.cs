using System.Collections.Generic;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class BuyOrPrintSignage : Entity
    {
        public Signage Signage { get; set; }
        public int Quantity { get; set; }
        public List<BuyOrPrintSignageProperty> Properties { get; set; }
        public List<BuyOrPrintSignageFormat> Formats { get; set; }
    }
}
