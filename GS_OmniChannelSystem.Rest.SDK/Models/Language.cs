using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Language : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long LanguageID { get; set; }
            public virtual string ISO { get; set; }
            public virtual string Name { get; set; }
        }

        public long LanguageID { get; set; }
        public string ISO { get; set; }
        public bool Online { get; set; }
        public string Name { get; set; }
        public List<EntityReference> Countries { get; set; }
        public List<TaxRate> TaxRates { get; set; }
    }
}
