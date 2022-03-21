using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class ArticleKeysRepository : BaseRepository<ArticleKey, ArticleKey.Summary>, Interfaces.IArticleKeysRepository
    {
        public ArticleKeysRepository(Context context)
            :base(context,"api/articlekeys")
        {
            
        }

    }
}