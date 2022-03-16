using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Interfaces
{
    public interface IShipmentOrdersRepository : IRepository<ShipmentOrder, ShipmentOrder.Summary>
    {
        ShipmentOrder.Summary CreateFastForOrder(long id, long transactionId, CreateShipmentOrderArgs args);
        string GetLabel(long id, ShipmentLabelType type = ShipmentLabelType.Shipment);
    }
}
