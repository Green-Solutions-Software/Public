using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class EBayAccount : MarketPlaceAccount
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public string MarketplaceUrl { get; set; }
            public string EpsServerUrl  { get; set; }
        }

        public string Token { get; set; }        
        public string MarketplaceUrl { get; set; }
        public string EpsServerUrl  { get; set; }
    }
}
