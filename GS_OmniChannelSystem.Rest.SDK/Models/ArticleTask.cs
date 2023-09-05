namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class ArticleTask : Entity
    {
        public long ArticleTaskID { get; set; }
        public EntityReference Task { get; set; }
        public int? FromMonth { get; set; }
        public int? ToMonth { get; set; }
    }
}