using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class AmazonAccount : MarketPlaceAccount
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public string MerchantId { get; set; }
            public string MarketplaceId { get; set; }
            public string AccessKeyId { get; set; }
            public string ServiceUrl { get; set; }
        }

        public string MerchantId { get; set; }
        public string MarketplaceId { get; set; }
        public string AccessKeyId { get; set; }
        public string SecretAccessKey { get; set; }
        public string ServiceUrl { get; set; }
    }
}
