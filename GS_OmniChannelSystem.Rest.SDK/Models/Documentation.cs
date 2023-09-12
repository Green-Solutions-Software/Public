namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Documentation : Entity
    {
        public long DocumentationID { get; set; }
        public PictureEntityReference Thumbnail { get; set; }
        public EntityReference DataFile { get; set; }
        public EntityReference Language { get; set; }
        public string Title { get; set; }
        public DocumentationType Type { get; set; }
    }

}
