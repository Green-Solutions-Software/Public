using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class PricelistPrice : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long PricelistPriceID { get; set; }
            public int? Quantity { get; set; }
            public double Price { get; set; }
        }

        public long PricelistPriceID { get; set; }

        public int? Quantity { get; set; }

        public double Price { get; set; }

        public double? PriceOld { get; set; }

        public bool PriceNet { get; set; }

        public bool TaxIncluded { get; set; }

        public EntityReference Currency { get; set; }

        public PriceListPriceType Type { get; set; }
    }
}
