using System.Collections.Generic;

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
