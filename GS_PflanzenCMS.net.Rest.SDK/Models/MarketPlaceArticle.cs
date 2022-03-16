using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class MarketPlaceArticle : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
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
