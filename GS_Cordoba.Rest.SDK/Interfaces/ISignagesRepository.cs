using GS.Cordoba.Rest.SDK.Classes;
using GS.Cordoba.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Interfaces
{
    public interface ISignagesRepository : IRepository<Signage, Signage.Summary>
    {
        Task<Paginated<Signage.Summary>> FindAll(long parentFolderID, string search, int pageIndex, int pageSize, string orderBy, long[] ids = null);

        Task<BuyOrPrintSignage> BuyOrPrint(long id);
    }
}
