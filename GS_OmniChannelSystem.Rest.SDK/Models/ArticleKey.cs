using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class ArticleKey : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long ArticleKeyID { get; set; }
            public string Info { get; set; }
            public string Value { get; set; }

            public string GetDisplayName(long languageID)
            {
                return this.Value;
            }
        }

        public class Patch : GS.OmniChannelSystem.Rest.SDK.Models.Patch
        {
            public long ArticleKeyID { get; set; }
            public int? StockQuantity { get; set; }
            public bool Inactive { get; set; }
            public double? PackingUnit { get; set; } // Verpackungseinheit (VE)
            public double? PackingSize { get; set; } // 10        
            public PriceUnitType? PackingUnitType { get; set; } // Liter
            public bool AvailableForDropshipping { get; set; }
            public bool NotAvailable { get; set; } // Nicht lieferbar
            public List<ArticleKeyPrice.Patch> Prices { get; set; }
            public List<ArticleKeyPhoto> Photos { get; set; }
            public List<TimePeriod> Available { get; set; } // n:1
            public TaxRate.Patch TaxRate { get; set; }
            public string AvailableForShippingText { get; set; } // Ausliefern
            public DeliverTime AvailableForShippingDeliverTime { get; set; } // Ausliefern Time
        }

        public long ArticleKeyID { get; set; }

        public string Info { get; set; }
        public string Value { get; set; }
        public string SupplierValue { get; set; }
        public short? Decimals { get; set; } // Nachkomma
        public double? PackingUnit { get; set; } // Verpackungseinheit (VE)
        public double? PackingSize { get; set; } // 10        
        public PriceUnitType? PackingUnitType { get; set; } // Liter
        public PackingFormType? PackingForm { get; set; } // Sack/Beutel
        public double? DeliverSize { get; set; } // 10
        public double? DeliverSize2 { get; set; } // 10
        public PriceUnitType? DeliverUnitType { get; set; } // Stck
        public DeliverType? DeliverType { get; set; } // EP/HVP
        public DeliverType? DeliverType2 { get; set; } // EP/HVP
        public PriceUnitType? DeliverUnitType2 { get; set; } // Stck
        public int? StockQuantity { get; set; }
        public string StorageLocation { get; set; }
        public string EAN { get; set; }
        public EntityReference Country { get; set; }
        public EntityReference TaxRate { get; set; }
        public EntityReference Category { get; set; }
        public EntityReference Teaser { get; set; }
        public string AvailableForShippingText { get; set; } // Ausliefern
        public DeliverTime AvailableForShippingDeliverTime { get; set; } // Ausliefern Time
        public string AvailableForRadiusDeliveryText { get; set; } // Im Umkreis ausliefern
        public DeliverTime AvailableForRadiusDeliveryDeliverTime { get; set; } // Im Umkreis ausliefern Time
        public string AvailableForClickAndCollectText { get; set; } // Click & Collect
        public DeliverTime AvailableForClickAndCollectDeliverTime { get; set; } // Click & Collect Time

        public double? GrowthFrom { get; set; }
        public double? GrowthTo { get; set; }
        public double? WeightFrom { get; set; }
        public double? WeightTo { get; set; }
        public double? WidthFrom { get; set; }
        public double? WidthTo { get; set; }
        public double? HeightFrom { get; set; }
        public double? HeightTo { get; set; }
        public double? CircumferenceFrom { get; set; }
        public double? CircumferenceTo { get; set; }

        public double? DeliverHeightFrom { get; set; }
        public double? DeliverHeightTo { get; set; }
        public double? LengthFrom { get; set; }
        public double? LengthTo { get; set; }

        public double? DepthFrom { get; set; }
        public double? DepthTo { get; set; }

        public double? PotSize { get; set; }
        public double? PotSizeL { get; set; }

        public double? FillAmountFrom { get; set; }
        public double? FillAmountTo { get; set; }

        public double? DiameterFrom { get; set; }
        public double? DiameterTo { get; set; }

        public double? LoadingCapacityFrom { get; set; }
        public double? LoadingCapacityTo { get; set; }

        public int? BloomingTimeFrom { get; set; }
        public int? BloomingTimeTo { get; set; }

        public TimePeriod BloomingTimePeriod { get; set; }
        public TimePeriod BloomingTimePeriod2 { get; set; }

        public int Priority { get; set; }

        public string Size { get; set; }
        public string Quality { get; set; }

        public List<EntityReference> Features { get; set; }
        public List<ArticleTask> Tasks { get; set; } // n:1

        public EntityReference Grower { get; set; }
        public EntityReference Brand { get; set; }
        public string BotanicName { get; set; }
        public string NameTranslation { get; set; }

        public List<ArticleKeyPhoto> Photos { get; set; }
        public List<ArticleKeyPrice> Prices { get; set; }
        public List<ArticleKeyAttachment> Attachments { get; set; }
        public List<TimePeriod> Available { get; set; } // n:1
        public List<CustomField> CustomFields { get; set; } // n:1        
        public List<EntityReference> MarketPlaceAccounts { get; set; }
        public List<ArticleKeyChannel> Channels { get; set; }
        public bool Inactive { get; set; }
        public bool NotAvailable { get; set; }
        public bool AvailableForShipping { get; set; } // Ausliefern
        public bool AvailableForRadiusDelivery { get; set; } // Im Umkreis ausliefern
        public bool AvailableForClickAndCollect { get; set; } // Click & Collect
        public bool AvailableForMarketPlaces { get; set; } // Marktplätze
        public bool AvailableForDropshipping { get; set; } // Herunterladen (individualisierbare Gutscheine)
        public bool AvailableForDownload { get; set; } // Herunterladen (individualisierbare Gutscheine)

        public string GetDisplayName(long languageID)
        {
            return this.Value;
        }
    }
}