using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class TaxRate : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long TaxRateID { get; set; }
            public double Percent { get; set; }
            public string Name { get; set; }
            public EntityReference Country { get; set; }
        }

        public class Patch : GS.OmniChannelSystem.Rest.SDK.Models.Patch
        {
        }

        public long TaxRateID { get; set; }
        public double Percent { get; set; }
        public string Name { get; set; }
        public EntityReference Country { get; set; }
    }
}
