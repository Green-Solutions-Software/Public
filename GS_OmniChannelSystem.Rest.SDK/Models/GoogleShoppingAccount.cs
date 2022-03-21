using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class GoogleShoppingAccount : MarketPlaceAccount
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public string MerchantId { get; set; }
            public string ClientId { get; set; }
        }

        public string MerchantId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
