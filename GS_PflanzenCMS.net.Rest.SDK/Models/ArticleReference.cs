using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class ArticleReference : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
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
