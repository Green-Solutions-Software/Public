namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class ArticleGroupProperty : Entity
    {
        public long ArticleGroupPropertyID { get; set; }
        public EntityReference Property { get; set; }
        public bool Required { get; set; }
        public bool Nullable { get; set; }
        public bool Article { get; set; }
        public bool ArticleKey { get; set; }
        public bool Range { get; set; }
    }
}