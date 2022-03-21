using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class ResultsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Result, GS.OmniChannelSystem.Rest.SDK.Models.Result.Summary>, IResultsRepository
    {
        public ResultsRepository(Context context)
            :base(context,"api/results")
        {
            
        }

        public Paginated<Result.Summary> FindAll(string search, int pageIndex, int pageSize, string orderBy, Filters.Results filter)
        {
            return FindAll(search, pageIndex, pageSize, orderBy, filter != null ? filter.ToString() : null);
        }
    }
}