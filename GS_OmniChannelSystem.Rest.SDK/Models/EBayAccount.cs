namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class EBayAccount : MarketPlaceAccount
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public string MarketplaceUrl { get; set; }
            public string EpsServerUrl  { get; set; }
        }

        public string Token { get; set; }        
        public string MarketplaceUrl { get; set; }
        public string EpsServerUrl  { get; set; }
    }
}
