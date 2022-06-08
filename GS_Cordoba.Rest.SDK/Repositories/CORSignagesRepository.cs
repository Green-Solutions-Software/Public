using GS.Cordoba.Rest.SDK.Classes;
using GS.Cordoba.Rest.SDK.Interfaces;
using GS.Cordoba.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Repositories
{
    public class CORSignagesRepository : Repository<Signage>, ISignagesRepository
    {
        public CORSignagesRepository(Context context) : base(context)
        {
        }

        public Task<Paginated<Signage.Summary>> FindAll(string search, int pageIndex, int pageSize, string orderBy, long[] ids = null)
        {
            return this.context.FindSignages(search, pageIndex, pageSize, orderBy);
        }

        public Task<Paginated<Signage.Summary>> FindAll(long parentFolderID, string search, int pageIndex, int pageSize, string orderBy, long[] ids = null)
        {
            return this.context.FindSignages(parentFolderID, search, pageIndex, pageSize, orderBy);
        }

        public Task<Signage> Get(long id)
        {
            return this.context.GetSignage(id);
        }

        public Task<BuyOrPrintSignage> BuyOrPrint(long id)
        {
            return this.context.BuyOrPrint(id);
        }


    }
}
