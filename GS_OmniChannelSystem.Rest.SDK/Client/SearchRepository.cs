using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

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