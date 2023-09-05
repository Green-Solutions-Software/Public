namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class PageLinkTarget : Entity
    {
        public long PageLinkTargetID { get; set; }
        public string Key { get; set; }
        public string Anchor { get; set; }
        public bool Manual { get; set; }
        public EntityReference Language { get; set; }
    }
}
