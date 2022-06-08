using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class ProgressHub
    {
        public string Proxy { get; set; }
        public string Invoke { get; set; }
        public string[] Params { get; set; }
        public long BasketID { get; set; }
    }
}
