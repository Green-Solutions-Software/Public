using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Article : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long ArticleID { get; set; }
            public string Name { get; set; }
            public string Name2 { get; set; }
            public string Name3 { get; set; }
            public string Description { get; set; }
            public long? External_COR_ID { get; set; }
            public bool Inactive { get; set; }

            public string GetDisplayName(long languageID)
            {
                return this.Name;
            }
        }
        public class Patch : GS.OmniChannelSystem.Rest.SDK.Models.Patch
        {
            public long ArticleID { get; set; }
            public bool Inactive { get; set; }
            public List<ArticleKey.Patch> Keys { get; set; } // n:1        
            public List<TimePeriod> Available { get; set; } // n:1
            public List<ArticlePhoto> Photos { get; set; }
        }



        public long ArticleID { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public List<EntityReference> Members { get; set; }

        public List<ArticlePhoto> Photos { get; set; }
        public List<ArticleAttachment> Attachments { get; set; }
        public List<EntityReference> ArticleGroups { get; set; }
        public List<EntityReference> Categories { get; set; }
        public List<EntityReference> Countries { get; set; }
        public List<ArticleReference> References { get; set; }

        public List<TimePeriod> Available { get; set; } // n:1
        public List<ArticleKey> Keys { get; set; } // n:1
        public List<ArticleText> Texts { get; set; } // n:1
        public List<ArticleTask> Tasks { get; set; } // n:1
        public List<ArticleRating> Ratings { get; set; } // n:1
        public List<EntityReference> Tags { get; set; }
        public List<EntityReference> Features { get; set; }
        public List<CustomField> CustomFields { get; set; } // n:1        
        public int? RatingCount { get; set; }
        public EntityReference Teaser { get; set; }
        public EntityReference Producer { get; set; }
        public bool Inactive { get; set; }
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
        public double? DeliverWidthFrom { get; set; }
        public double? DeliverWidthTo { get; set; }
        public double? DeliverLengthFrom { get; set; }
        public double? DeliverLengthTo { get; set; }
        public double? LengthFrom { get; set; }
        public double? LengthTo { get; set; }
        public int? PlantsPerMeter { get; set; }
        public int? External_State { get; set; }
        public double? DepthFrom { get; set; }
        public double? DepthTo { get; set; }
        public bool DropShip { get; set; }
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
        public bool Stock { get; set; }
        public int? Priority { get; set; }
        public TimePeriod BloomingTimePeriod { get; set; }
        public TimePeriod BloomingTimePeriod2 { get; set; }
        public string Size { get; set; }
        public string Quality { get; set; }
        public EntityReference Grower { get; set; }
        public EntityReference Brand { get; set; }
        public string BotanicName { get; set; }
        public string NameTranslation { get; set; }
        public EntityReference SynchronizerSettings { get; set; }
        public EntityReference Supplier { get; set; }
        public string External_Key2 { get; set; }
        public string External_RowVersion2 { get; set; }

        public string GetDisplayName(long languageID)
        {
            return this.Name;
        }

    }
}
