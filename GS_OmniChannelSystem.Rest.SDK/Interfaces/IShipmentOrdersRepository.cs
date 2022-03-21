using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IShipmentOrdersRepository : IRepository<ShipmentOrder, ShipmentOrder.Summary>
    {
        ShipmentOrder.Summary CreateFastForOrder(long id, long transactionId, CreateShipmentOrderArgs args);
        string GetLabel(long id, ShipmentLabelType type = ShipmentLabelType.Shipment);
    }
}
