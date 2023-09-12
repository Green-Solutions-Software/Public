using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class PaginatedSearch:Paginated<Item>
    {
        public List<SearchFacett> Facetts { get; set; }

        public string[] DoYouMean { get; set; }
    }
}
