namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Channel : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long ChannelID { get; set; }
            public virtual string Name { get; set; }
            public ChannelType Type { get; set; }
            public virtual EntityReference MarketPlace { get; set; }
        }

        public long ChannelID { get; set; }
        public ChannelType Type { get; set; }
        public virtual string Name { get; set; }
        public bool Relay { get; set; }
        public string DatabaseSetup { get; set; }
        public string ConnectionString { get; set; }
        public string Revision { get; set; }
        public virtual EntityReference MarketPlace { get; set; }
    }
}
