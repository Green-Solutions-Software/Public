using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
