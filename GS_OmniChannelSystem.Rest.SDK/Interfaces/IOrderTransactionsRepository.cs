using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IOrderTransactionsRepository : IRepository
    {
        void UpdateStatus(long id, OrderTransactionArgs args);
        Job UpdateStatusAsync(long id, OrderTransactionArgs args);
        T UpdateStatusAsync<T>(long id, OrderTransactionArgs args) where T : Job,new();
    }
}
