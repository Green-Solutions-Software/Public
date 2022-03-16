using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class OrdersRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Order, GS.PflanzenCMS.Rest.SDK.Models.Order.Summary>, IOrdersRepository
    {
        public OrdersRepository(Context context)
            :base(context, "api/orders")
        {
            
        }

        public GS.PflanzenCMS.Rest.SDK.Api.Args.CreateOrderArgs.Result Create(CreateOrderArgs order)
        {
            return this.context.CreateOrder(order);
        }

        public GS.PflanzenCMS.Rest.SDK.Api.Args.CreateCashdeskArgs.Result CreateCashDesk(CreateCashdeskArgs order)
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
            return FindAll(search, pageIndex, pageSize, orderBy, filter != null ? filter.ToString() : (string)null, ids != null ? GS.PflanzenCMS.Rest.SDK.Classes.Strings.ListStringCombine(ids,m=>m.ToString(),",") : null);
        }
    }
}