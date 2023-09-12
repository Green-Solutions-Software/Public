using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class PricelistItem : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long PricelistItemID { get; set; }
            public EntityReference Article { get; set; }
        }

        public long PricelistItemID { get; set; }
        public EntityReference Article { get; set; }
        public EntityReference Pricelist { get; set; }

        public List<PricelistKey> Keys { get; set; }
    }
}
