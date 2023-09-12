using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class OrdersRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Order, GS.OmniChannelSystem.Rest.SDK.Models.Order.Summary>, IOrdersRepository
    {
        public OrdersRepository(Context context)
            :base(context, "api/orders")
        {
            
        }

        public GS.OmniChannelSystem.Rest.SDK.Api.Args.CreateOrderArgs.Result Create(CreateOrderArgs order)
        {
            return this.context.CreateOrder(order);
        }

        public GS.OmniChannelSystem.Rest.SDK.Api.Args.CreateCashdeskArgs.Result CreateCashDesk(CreateCashdeskArgs order)
        {
            return this.context.CreateCashDesk(order);
        }

        public Paginated<Order.Summary> FindAllForShop(string search, int pageIndex, int pageSize, string orderBy, string filter)
        {
            return this.context.FindAllOrdersForShop(search, pageIndex, pageSize, orderBy, filter);
        }

        public Dialog Dialog()
        {
            return this.context.GetOrdersDialog();
        }

        public Order UpdateStatus(long id, OrderTransactionArgs args)
        {
            return this.context.UpdateOrderTransactionStatus(id, args);
        }

        public OrderUpdates[] UpdatePositions(long id, OrderTransactionPositions positions)
        {
            return this.context.UpdateOrderTransactionPositionStatus(id, positions);
        }

        public Paginated<Order.Summary> FindAllForShop(string search, int pageIndex, int pageSize, string orderBy, Filters.Orders filter)
        {
            return FindAllForShop(search, pageIndex, pageSize, orderBy, filter != null ? filter.ToString() : null);
        }
        public Paginated<Order.Summary> FindAll(string search, int pageIndex, int pageSize, string orderBy, Filters.Orders filter = null, long[] ids = null)
        {
            return FindAll(search, pageIndex, pageSize, orderBy, filter != null ? filter.ToString() : (string)null, ids != null ? GS.OmniChannelSystem.Rest.SDK.Classes.Strings.ListStringCombine(ids,m=>m.ToString(),",") : null);
        }

        public Order GetForShop(string external_key, string[] properties = null)
        {
            return this.context.Get<Order>(this.resource + "/all/ext?ext=" + HttpUtility.UrlEncode(external_key), properties);
        }
    }
}