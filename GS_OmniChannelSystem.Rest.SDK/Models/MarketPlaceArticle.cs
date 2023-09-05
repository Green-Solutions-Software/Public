namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class MarketPlaceArticle : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public Article Article { get; set; }
            public ArticleKey ArticleKey { get; set; }
        }

        public long MarketPlaceArticleID { get; set; }
        public string ProductID { get; set; }

        public Article Article { get; set; }
        public ArticleKey ArticleKey { get; set; }
        public byte[] ExternalRowVersion { get; set; }
    }
}
