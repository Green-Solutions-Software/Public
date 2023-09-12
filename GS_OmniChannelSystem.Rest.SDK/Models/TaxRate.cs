namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class TaxRate : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long TaxRateID { get; set; }
            public double Percent { get; set; }
            public string Name { get; set; }
            public EntityReference Country { get; set; }
        }

        public class Patch : GS.OmniChannelSystem.Rest.SDK.Models.Patch
        {
        }

        public long TaxRateID { get; set; }
        public double Percent { get; set; }
        public string Name { get; set; }
        public EntityReference Country { get; set; }
    }
}
