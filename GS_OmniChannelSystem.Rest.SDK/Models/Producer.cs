namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Producer : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long ProducerID { get; set; }
            public string Name { get; set; }
        }

        public Producer()
        {
        }

        public long ProducerID { get; set; }
        public string Name { get; set; }
    }
}
