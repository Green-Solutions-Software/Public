using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IOrdersRepository 
        : IRepository<GS.OmniChannelSystem.Rest.SDK.Models.Order, GS.OmniChannelSystem.Rest.SDK.Models.Order.Summary>
        , IFilteredRepository<GS.OmniChannelSystem.Rest.SDK.Models.Order, GS.OmniChannelSystem.Rest.SDK.Models.Order.Summary, GS.OmniChannelSystem.Rest.SDK.Filters.Orders>
    {
        CreateOrderArgs.Result Create(GS.OmniChannelSystem.Rest.SDK.Api.Args.CreateOrderArgs value);
        CreateCashdeskArgs.Result CreateCashDesk(CreateCashdeskArgs order);

        Paginated<Order.Summary> FindAllForShop(string search, int pageIndex, int pageSize, string orderBy, string filter);
        Paginated<Order.Summary> FindAllForShop(string search, int pageIndex, int pageSize, string orderBy, Filters.Orders filter);
        Dialog Dialog();
        Order UpdateStatus(long id, OrderTransactionArgs args);
        OrderUpdates[] UpdatePositions(long id, OrderTransactionPositions positions);
        Order GetForShop(string external_key, string[] properties = null);
    }
}
