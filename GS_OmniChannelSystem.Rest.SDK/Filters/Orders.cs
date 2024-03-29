﻿using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Filters
{
    public class Orders : Base
    {
        protected override void addFilter(Dictionary<string, string> dict)
        {
            if(ItemsFrom != null)
            {
                if (ItemsTo == null)
                    throw new ArgumentNullException("PositionsTo");
                dict["items"] = this.ItemsFrom.ToString() + "-" + this.ItemsTo.ToString();
            }

            if (WeightFrom != null)
            {
                if (WeightTo == null)
                    throw new ArgumentNullException("WeightTo");
                dict["weight"] = this.WeightFrom.ToString() + "-" + this.WeightTo.ToString();
            }

            if (WithoutSupplier)
                dict["supplierid"] = "null";

            if (CategoryIds != null)
                dict["categoryid"] = GS.OmniChannelSystem.Rest.SDK.Classes.Strings.ListStringCombine(CategoryIds, m=>m.ToString(),",");

            if (BrandIds != null)
                dict["brandid"] = GS.OmniChannelSystem.Rest.SDK.Classes.Strings.ListStringCombine(BrandIds, m => m.ToString(), ",");
            if (ProducerIds != null)
                dict["producerid"] = GS.OmniChannelSystem.Rest.SDK.Classes.Strings.ListStringCombine(ProducerIds, m => m.ToString(), ",");

            if (StockLocations != null)
                dict["stocklocations"] = GS.OmniChannelSystem.Rest.SDK.Classes.Strings.ListStringCombine(StockLocations, m => m.ToString(), ",");

            if (Status != null)
                dict["status"] = ((short)Status).ToString();

            if (OwnerMemberID != null)
                dict["ownermemberid"] = this.OwnerMemberID.ToString();

            if (CreatedOnFrom != null)
            {
                if (CreatedOnTo == null)
                    throw new ArgumentNullException("CreatedOnTo");
                dict["createdon"] = CreatedOnFrom.Value.Ticks.ToString() + "-" + CreatedOnTo.Value.Ticks.ToString();
            }

        }

        // Aufträge mit Positionen ohne Dropshipper
        public bool WithoutSupplier { get; set; }

        // Anzahl Positionen
        public int? ItemsFrom { get; set; }
        public int? ItemsTo { get; set; }

        // Gewicht
        public double? WeightFrom { get; set; }
        public double? WeightTo { get; set; }

        // Kategorien
        public long[] CategoryIds { get; set; }

        // Hersteller
        public long[] ProducerIds { get; set; }

        // Marken
        public long[] BrandIds { get; set; }

        // Lagerort
        public string[] StockLocations { get; set; }

        // Status
        public OrderStatusType? Status { get; set; }

        // Erstellt
        public DateTime? CreatedOnFrom { get; set; }
        public DateTime? CreatedOnTo { get; set; }

        // Kunde
        public long? OwnerMemberID { get; set; }
    }
}
