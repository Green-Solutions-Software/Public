using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IShipmentOrdersRepository : IRepository<ShipmentOrder, ShipmentOrder.Summary>
    {
        ShipmentOrder.Summary CreateFastForOrder(long id, long transactionId, CreateShipmentOrderArgs args);
        string GetLabel(long id, ShipmentLabelType type = ShipmentLabelType.Shipment);
    }
}
