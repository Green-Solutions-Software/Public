namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class CustomerGroup : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long CustomerGroupID { get; set; }
            public string Name { get; set; }
            public virtual string Key { get; set; }
        }

        public long CustomerGroupID { get; set; }
        public string Name { get; set; }
        public virtual string Key { get; set; }
    }
}
