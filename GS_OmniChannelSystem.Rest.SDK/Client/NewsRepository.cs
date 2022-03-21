using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class NewsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.News, GS.OmniChannelSystem.Rest.SDK.Models.News.Summary>, INewsRepository
    {
        public NewsRepository(Context context)
            :base(context, "api/news")
        {
            
        }

    }
}