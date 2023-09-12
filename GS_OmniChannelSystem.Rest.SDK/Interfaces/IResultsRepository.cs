using GS.OmniChannelSystem.Rest.SDK.Models;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IResultsRepository : IRepository<GS.OmniChannelSystem.Rest.SDK.Models.Result, GS.OmniChannelSystem.Rest.SDK.Models.Result.Summary>
    {
        Paginated<Result.Summary> FindAll(string search, int pageIndex, int pageSize, string orderBy, Filters.Results filter);
    }
}
