namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Teaser : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long TeaserID { get; set; }
            public string Color { get; set; }
            public string Name { get; set; }
            public string Key { get; set; }
        }

        public long TeaserID { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }

    }
}
