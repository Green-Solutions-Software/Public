using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class PaginatedSearch:Paginated<Item>
    {
        public List<SearchFacett> Facetts { get; set; }

        public string[] DoYouMean { get; set; }
    }
}
