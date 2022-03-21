using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class ArticlePropertiesRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.ArticleProperty, GS.OmniChannelSystem.Rest.SDK.Models.ArticleProperty.Summary>, IArticlePropertiesRepository
    {
        public ArticlePropertiesRepository(Context context)
            :base(context, "api/articleproperties")
        {
            
        }
    }
}