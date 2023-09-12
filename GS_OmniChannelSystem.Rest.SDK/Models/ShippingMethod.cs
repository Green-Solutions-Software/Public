namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class ShippingMethod : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long ShippingMethodID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public PictureEntityReference Picture { get; set; }

            public Summary()
            {

            }

            public Summary(ShippingMethod other)
            {
                this.Name = other.Name;
                this.Description = other.Description;
                this.Picture = other.Picture;
            }

            public string GetDisplayName(long languageID)
            {
                return this.Name;
            }
        }

        public long ShippingMethodID { get; set; }
        public string Name { get; set; }
        public string EstimatedShippingDuration { get; set; }
        public string Description { get; set; }
        public string ServiceProvider { get; set; }
        public PictureEntityReference Picture { get; set; }
        public bool Default { get; set; }
        public bool IsAbstract { get; set; }
        public EntityReference Parent { get; set; }
        public string TrackAndTraceUrl { get; set; }

    }
}
