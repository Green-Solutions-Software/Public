using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;
using System.IO;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class SearchRepository : BaseRepository, ISearchRepository
    {
        public SearchRepository(Context context)
            :base(context)
        {
            
        }

        public Paginated<Item> Search(string search, int pageIndex, int pageSize, string orderBy, SearchArgs args)
        {
            return this.context.Search(search, pageIndex, pageSize, orderBy, args);
        }

    }
}