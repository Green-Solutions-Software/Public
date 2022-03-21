using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IDocumentsRepository
    {
        string GetForOrder(long orderId, DocumentationType type);
        string GetForOrders(long[] orderId, DocumentationType type);
        string GetForOrder(long orderId, long orderTransactionId, DocumentationType type);
    }
}
