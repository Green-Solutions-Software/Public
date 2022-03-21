using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Country : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long CountryID { get; set; }
            public virtual string ISO { get; set; }
            public virtual string Name { get; set; }
        }

        public long CountryID { get; set; }
        public string ISO { get; set; }
        public string Name { get; set; }
        public List<EntityReference> Countries { get; set; }
        public List<TaxRate> TaxRates { get; set; }
    }
}
