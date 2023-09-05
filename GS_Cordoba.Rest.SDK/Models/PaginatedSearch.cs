using GS.Cordoba.Rest.SDK.Classes;
using System.Collections.Generic;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class PaginatedSearch:Paginated<Item>
    {
        public List<SearchFacett> Facetts { get; set; }

        public string[] DoYouMean { get; set; }
    }
}
