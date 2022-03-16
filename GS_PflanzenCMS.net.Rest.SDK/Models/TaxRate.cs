using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class TaxRate : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long TaxRateID { get; set; }
            public double Percent { get; set; }
            public string Name { get; set; }
            public EntityReference Country { get; set; }
        }

        public class Patch : GS.PflanzenCMS.Rest.SDK.Models.Patch
        {
        }

        public long TaxRateID { get; set; }
        public double Percent { get; set; }
        public string Name { get; set; }
        public EntityReference Country { get; set; }
    }
}
