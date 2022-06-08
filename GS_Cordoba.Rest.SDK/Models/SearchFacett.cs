using System;
using System.Collections.Generic;
using System.Linq;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class SearchFacett
    {
        public string Name { get; set; }
        public string Title { get; set; }

        public List<SearchFacettValue> Values { get; set; }
    }
}