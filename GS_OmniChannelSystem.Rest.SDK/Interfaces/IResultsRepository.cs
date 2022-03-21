using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IResultsRepository : IRepository<GS.OmniChannelSystem.Rest.SDK.Models.Result, GS.OmniChannelSystem.Rest.SDK.Models.Result.Summary>
    {
        Paginated<Result.Summary> FindAll(string search, int pageIndex, int pageSize, string orderBy, Filters.Results filter);
    }
}
