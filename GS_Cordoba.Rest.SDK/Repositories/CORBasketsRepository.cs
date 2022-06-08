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
    public class CORBasketsRepository : Repository<Basket>, IBasketsRepository
    {
        public CORBasketsRepository(Context context) : base(context)
        {
        }

        public Task<Paginated<Basket.Summary>> FindAll(string search, int pageIndex, int pageSize, string orderBy, long[] ids = null)
        {
            return this.context.FindBaskets(search, pageIndex, pageSize, orderBy);
        }

        public Task<Basket> Get(long id)
        {
            return this.context.GetBasket(id);
        }

        public Task<Basket.Summary> AddToPrintList(BuyOrPrintSignage model)
        {
            return this.context.AddToPrintList(model);
        }

        public Task<ProgressHub> PrintListPrintTemp(BuyOrPrintSignage model)
        {
            return this.context.PrintListPrintTemp(model);
        }

        public Task<Basket.Summary> DeleteFromPrintList(long id)
        {
            return this.context.DeleteFromPrintList(id);
        }

        public Task<ProgressHub> PrintListPrint(PrintSettings settings)
        {
            return this.context.PrintListPrint(settings);
        }

        public Task<Paginated<BasketItem>> FindAllPrintList(int pageIndex = 0, int pageSize = 10)
        {
            return this.context.FindAllPrintList(pageIndex, pageSize);
        }

        public Task PrintListClear()
        {
            return this.context.PrintListClear();
        }

    }
}
