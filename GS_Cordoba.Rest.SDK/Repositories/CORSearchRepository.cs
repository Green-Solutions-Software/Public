using GS.Cordoba.Rest.SDK.Interfaces;
using GS.Cordoba.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Repositories
{
    public class CORSearchRepository : Repository, ISearchRepository
    {
        public CORSearchRepository(Context context) : base(context)
        {
        }

        public Task<PaginatedSearch> Search(string search, int pageIndex, int pageSize, string orderBy, SearchArgs args)
        {
            return this.context.Search(search, pageIndex, pageSize, orderBy, args);
        }

    }
}
