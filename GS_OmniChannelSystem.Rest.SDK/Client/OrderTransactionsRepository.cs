using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;
using GS.OmniChannelSystem.Rest.SDK.Models;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class OrderTransactionsRepository : BaseRepository, IOrderTransactionsRepository
    {
        public OrderTransactionsRepository(Context context)
            :base(context)
        {

        }

        //public void UpdateStatus(OrderTransactionArgs args)
        //{
        //    this.context.UpdateOrderTransactionStatus(args);
        //}
        public void UpdateStatus(long id, OrderTransactionArgs args)
        {
            this.context.UpdateOrderTransactionStatus(id, args);
        }

        public Job UpdateStatusAsync(long id, OrderTransactionArgs args)
        {
            return this.context.UpdateOrderTransactionStatusAsync(id, args);
        }

        public T UpdateStatusAsync<T>(long id, OrderTransactionArgs args) where T : Job,new()
        {
            return this.context.UpdateOrderTransactionStatusAsync<T>(id, args);
        }

        

    }
}