namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class ArticleKeyPrice : Entity
    {
        public class Patch : GS.OmniChannelSystem.Rest.SDK.Models.Patch
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
        public double? PriceUVP { get; set; }
        public double? PriceUnitAmount { get; set; } // Pro 10
        public PriceUnitType? ValueUnitType { get; set; } // Liter
        public double? PriceOld { get; set; }
        public bool PriceNet { get; set; } // Netto-Preis! Keine Rabatte
        public bool TaxIncluded { get; set; } // Incl. MwSt
        public EntityReference Currency { get; set; }
        public PriceListPriceType Type { get; set; } // Liter

    }
}