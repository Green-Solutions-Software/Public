using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class NewsRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.News, GS.PflanzenCMS.Rest.SDK.Models.News.Summary>, INewsRepository
    {
        public NewsRepository(Context context)
            :base(context, "api/news")
        {
            
        }

    }
}