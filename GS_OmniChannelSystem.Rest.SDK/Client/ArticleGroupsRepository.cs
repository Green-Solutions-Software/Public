using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class ArticleGroupsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.ArticleGroup, GS.OmniChannelSystem.Rest.SDK.Models.ArticleGroup.Summary>, IArticleGroupsRepository
    {
        public ArticleGroupsRepository(Context context)
            :base(context, "api/articlegroups")
        {
            
        }
    }
}