using GS.Cordoba.Rest.SDK.Classes;
using GS.Cordoba.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Interfaces
{
    public interface IBasketsRepository : IRepository<Basket, Basket.Summary>
    {
        Task<Basket.Summary> AddToPrintList(BuyOrPrintSignage model);
        Task<ProgressHub> PrintListPrintTemp(BuyOrPrintSignage model);

        Task<Basket.Summary> DeleteFromPrintList(long id);
        Task<Paginated<BasketItem>> FindAllPrintList(int pageIndex = 0, int pageSize = 10);
        Task<ProgressHub> PrintListPrint(PrintSettings settings);
        Task PrintListClear();
    }
}
