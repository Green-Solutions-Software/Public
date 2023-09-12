namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class ArticleText : Entity
    {
        public long ArticleTextID { get; set; }
        public short Position { get; set; }
        public TextType Type { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
    }
}