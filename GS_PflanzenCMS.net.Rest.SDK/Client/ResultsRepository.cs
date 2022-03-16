using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class ResultsRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Result, GS.PflanzenCMS.Rest.SDK.Models.Result.Summary>, IResultsRepository
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