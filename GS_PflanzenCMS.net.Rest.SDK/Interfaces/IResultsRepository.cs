using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Interfaces
{
    public interface IResultsRepository : IRepository<GS.PflanzenCMS.Rest.SDK.Models.Result, GS.PflanzenCMS.Rest.SDK.Models.Result.Summary>
    {
        Paginated<Result.Summary> FindAll(string search, int pageIndex, int pageSize, string orderBy, Filters.Results filter);
    }
}
