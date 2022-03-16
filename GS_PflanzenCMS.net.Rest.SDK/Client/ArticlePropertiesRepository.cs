using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class ArticlePropertiesRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.ArticleProperty, GS.PflanzenCMS.Rest.SDK.Models.ArticleProperty.Summary>, IArticlePropertiesRepository
    {
        public ArticlePropertiesRepository(Context context)
            :base(context, "api/articleproperties")
        {
            
        }
    }
}