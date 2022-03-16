using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class ArticleKeysRepository : BaseRepository<ArticleKey, ArticleKey.Summary>, Interfaces.IArticleKeysRepository
    {
        public ArticleKeysRepository(Context context)
            :base(context,"api/articlekeys")
        {
            
        }

    }
}