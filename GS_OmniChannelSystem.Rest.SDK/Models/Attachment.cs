namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Attachment: Entity
    {
        public long AttachmentID { get; set; }
        public EntityReference DataFile { get; set; }
        public EntityReference Language { get; set; }
        public string Title { get; set; }
    }

}
