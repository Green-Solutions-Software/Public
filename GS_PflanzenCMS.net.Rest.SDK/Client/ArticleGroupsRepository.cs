using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class ArticleGroupsRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.ArticleGroup, GS.PflanzenCMS.Rest.SDK.Models.ArticleGroup.Summary>, IArticleGroupsRepository
    {
        public ArticleGroupsRepository(Context context)
            :base(context, "api/articlegroups")
        {
            
        }
    }
}