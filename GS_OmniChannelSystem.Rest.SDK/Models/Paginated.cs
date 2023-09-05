using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Paginated<T>: Base where T:class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

        public List<T> Items { get; set; }

        public Paginated()
        {
            this.Items = new List<T>();
        }
    }
}
