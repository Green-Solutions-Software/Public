using System;
using System.Collections.Generic;
using System.Linq;

namespace GS.Cordoba.Rest.SDK.Classes
{
    public class Paginated<T> where T:class
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

        public Paginated(int pageIndex, int pageSize)
        {
            this.Items = new List<T>();
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }
    }
}
