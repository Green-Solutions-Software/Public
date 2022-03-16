using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Interfaces
{
    public interface IOrdersRepository 
        : IRepository<GS.PflanzenCMS.Rest.SDK.Models.Order, GS.PflanzenCMS.Rest.SDK.Models.Order.Summary>
        , IFilteredRepository<GS.PflanzenCMS.Rest.SDK.Models.Order, GS.PflanzenCMS.Rest.SDK.Models.Order.Summary, GS.PflanzenCMS.Rest.SDK.Filters.Orders>
    {
        CreateOrderArgs.Result Create(GS.PflanzenCMS.Rest.SDK.Api.Args.CreateOrderArgs value);
        CreateCashdeskArgs.Result CreateCashDesk(CreateCashdeskArgs order);

        Paginated<Order.Summary> FindAllForShop(string search, int pageIndex, int pageSize, string orderBy, string filter);
        Paginated<Order.Summary> FindAllForShop(string search, int pageIndex, int pageSize, string orderBy, Filters.Orders filter);
        Dialog Dialog();
        Order UpdateStatus(long id, OrderTransactionArgs args);
        OrderUpdates[] UpdatePositions(long id, OrderTransactionPositions positions);
    }
}
