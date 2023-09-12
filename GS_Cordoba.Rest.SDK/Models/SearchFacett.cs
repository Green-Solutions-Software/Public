using System.Collections.Generic;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class SearchFacett
    {
        public string Name { get; set; }
        public string Title { get; set; }

        public List<SearchFacettValue> Values { get; set; }
    }
}