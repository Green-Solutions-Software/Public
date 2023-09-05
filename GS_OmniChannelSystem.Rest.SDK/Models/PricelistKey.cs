using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class PricelistKey : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long PricelistKeyID { get; set; }
            public EntityReference ArticleKey { get; set; }
        }

        public long PricelistKeyID { get; set; }

        public EntityReference ArticleKey { get; set; }

        public string CustomerEAN { get; set; }

        public string CustomerArticleNumber { get; set; }

        public double? CustomerPrice { get; set; }

        public bool Individual { get; set; }

        public bool Top { get; set; }

        public EntityReference Currency { get; set; }

        public List<PricelistPrice> Prices { get; set; }
    }
}
