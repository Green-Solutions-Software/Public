﻿namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class ArticleReference : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long ArticleReferenceID { get; set; }

            public string GetDisplayName(long languageID)
            {
                return ArticleReferenceID.ToString();
            }
        }

        public ArticleReference(ArticleReference articleReference)
        {
            this.Article = articleReference.Article;
            this.ArticleKey = articleReference.ArticleKey;
        }

        public ArticleReference()
        {

        }

        public long ArticleReferenceID { get; set; }

        public string KeyValue { get; set; }
        public EntityReference Article { get; set; }
        public EntityReference ArticleKey { get; set; }
        public ArticleReferenceType ArticleReferenceType { get; set; }
    }
}
