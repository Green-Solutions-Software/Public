namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Media : Entity
    {
        public long MediaID { get; set; }
        public EntityReference Video { get; set; }
        public EntityReference Language { get; set; }
        public string Title { get; set; }
    }

}
