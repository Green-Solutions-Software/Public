namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Right : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long RightID { get; set; }
            public string Name { get; set; }
        }

        public Right()
        {
        }

        public long RightID { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
    }
}
