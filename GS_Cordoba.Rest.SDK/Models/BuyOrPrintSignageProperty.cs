using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class BuyOrPrintSignageProperty
    {
        public string ContentId { get; set; }
        public string Name { get; set; }

        public string Value { get; set; }
        public string OriginalValue { get; set; }
        public string Displayname { get; set; }

        public string Row { get; set; }

        public int WidthXS { get; set; }
    }
}
