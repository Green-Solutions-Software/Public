using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class MarketPlaceAccount : Entity
    {
        public string Name { get; set; }
        public string Provider { get; set; }
        public List<MarketPlaceArticle> Articles { get; set; }

        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public string Name { get; set; }
            public string Provider { get; set; }

        }

    }
}
