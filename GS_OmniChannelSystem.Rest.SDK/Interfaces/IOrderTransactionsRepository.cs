using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IOrderTransactionsRepository : IRepository
    {
        void UpdateStatus(long id, OrderTransactionArgs args);
        Job UpdateStatusAsync(long id, OrderTransactionArgs args);
        T UpdateStatusAsync<T>(long id, OrderTransactionArgs args) where T : Job,new();
    }
}
