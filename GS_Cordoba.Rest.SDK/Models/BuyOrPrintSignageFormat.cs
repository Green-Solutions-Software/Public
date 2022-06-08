using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class BuyOrPrintSignageFormat : Entity
    {
        public Format Format { get; set; }
        public bool Checked { get; set; }

        public dynamic Fields;
            
    }
}
