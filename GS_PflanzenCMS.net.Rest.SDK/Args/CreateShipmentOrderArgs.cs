using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Api.Args
{
    public class CreateShipmentOrderArgs
    {
        public int Quantity { get; set; }
        public double[] WeightsInKg { get; set; }
        public string[] Numbers { get; set; }
    }
}
