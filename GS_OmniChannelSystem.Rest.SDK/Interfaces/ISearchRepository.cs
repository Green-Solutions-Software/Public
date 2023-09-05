using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface ISearchRepository
    {
        Paginated<Item> Search(string search, int pageIndex, int pageSize, string orderBy, SearchArgs args);
    }
}
