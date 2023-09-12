using System;
using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class CalculationGroupItem : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long CalculationGroupItemID { get; set; }
            public string Name { get; set; }
            public int Priority { get; set; }

            public string GetDisplayName(long languageID)
            {
                return this.Name;
            }
        }

        public long CalculationGroupItemID { get; set; }
        public CalculationGroupItemType Type { get; set; }
        public EntityReference Currency { get; set; }

        public EntityReference CalculationGroup { get; set; }

        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public EntityReference AffectedArticleKey { get; set; }
        public bool AffectedArticleKeyRemovable { get; set; }
        public bool AffectedArticleKeyAddable { get; set; }
        public bool TaxIncluded { get; set; }
        public EntityReference TaxRate { get; set; }
        public bool? HasDebitCard { get; set; }
        public TransactionType? TransactionType { get; set; }
        public InvoiceStateType? InvoiceState { get; set; }
        public double? TurnoverFrom { get; set; }
        public double? TurnoverTo { get; set; }
        public double? TurnoverSupplierFrom { get; set; }
        public double? TurnoverSupplierTo { get; set; }
        public int? QuantityFrom { get; set; }
        public int? QuantityTo { get; set; }

        public int? StockQuantityFrom { get; set; }
        public int? StockQuantityTo { get; set; }

        public int? QuantitySupplierFrom { get; set; }
        public int? QuantitySupplierTo { get; set; }
        public double? WeightFrom { get; set; }
        public double? WeightTo { get; set; }
        public double? DeliverHeightFrom { get; set; }
        public double? DeliverHeightTo { get; set; }
        public double? PerimeterFrom { get; set; }
        public double? PerimeterTo { get; set; }
        public int Priority { get; set; }
        public bool Invalid { get; set; }
        public bool Negate { get; set; }
        public double? UtalizationValueFrom { get; set; }
        public double? UtalizationValueTo { get; set; }
        public DeliverType? CarrierType { get; set; }
        public List<EntityReference> CustomerGroups { get; set; }
        public List<EntityReference> Suppliers { get; set; }
        public List<EntityReference> ArticleGroups { get; set; }
        public List<EntityReference> Members { get; set; }
        public List<EntityReference> Categories { get; set; }
        public List<EntityReference> PaymentMethods { get; set; }
        public List<EntityReference> ShippingMethods { get; set; }
        //public ICollection<CalculationGroupItemShipping> Shipping { get; set; }
        public List<EntityReference> MarketPlaceAccounts { get; set; }
        public List<EntityReference> Channels { get; set; }
        public List<EntityReference> Vouchers { get; set; }
        public List<EntityReference> Regions { get; set; }
        public List<EntityReference> Pricelists { get; set; }
        public List<EntityReference> ShippingCountries { get; set; }
        public List<EntityReference> ShippingRegions { get; set; }
        public double Value { get; set; } // 10 % 
        public string ValueFormula { get; set; }
        public CalulationPrincipleValueType ValueType { get; set; } // Prozent / Wert
        public CalulationPrincipleType PrincipleType { get; set; } // Aufschlag / Rabatt
        public PercentOperationType PercentOperationType { get; set; } // Mal oder geteilt bei Prozent?
        public string Notes { get; set; }


    }
}
