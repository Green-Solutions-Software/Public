namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class FeatureType : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long FeatureTypeID { get; set; }
            public virtual string Name { get; set; }
            public virtual string Key { get; set; }
        }

        public long FeatureTypeID { get; set; }
        public string Name { get; set; }
        public FeatureEnumType? Type { get; set; }
        
        public string Key { get; set; }

        public bool? Indexable { get; set; }

        public bool? IndexMultilang { get; set; }

        public bool? IndexFacetable { get; set; }

        public bool? IndexFilterable { get; set; }

        public bool? IndexSearchable { get; set; }
    }
}
