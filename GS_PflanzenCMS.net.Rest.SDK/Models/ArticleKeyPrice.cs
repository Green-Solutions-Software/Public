using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class ArticleKeyPrice : Entity
    {
        public class Patch : GS.PflanzenCMS.Rest.SDK.Models.Patch
        {
            public long ArticleKeyPriceID { get; set; }
            public int Quantity { get; set; } // Stückzahl
            public double Price { get; set; } // 10 EUR
            public bool TaxIncluded { get; set; } // Incl. MwSt
            public EntityReference Currency { get; set; }
        }

        public long ArticleKeyPriceID { get; set; }
        public int? Quantity { get; set; } // ab x Stück
        public double Price { get; set; } // 10 EUR
        public double? PriceUnitAmount { get; set; } // Pro 10
        public PriceUnitType? ValueUnitType { get; set; } // Liter
        public double? PriceOld { get; set; }
        public bool PriceNet { get; set; } // Netto-Preis! Keine Rabatte
        public bool TaxIncluded { get; set; } // Incl. MwSt
        public EntityReference Currency { get; set; }
        public PriceListPriceType Type { get; set; } // Liter

    }
}