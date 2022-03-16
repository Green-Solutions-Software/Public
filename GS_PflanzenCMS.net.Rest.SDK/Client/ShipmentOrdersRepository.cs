using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Interfaces;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class ShipmentOrdersRepository : BaseRepository<ShipmentOrder, ShipmentOrder.Summary>, IShipmentOrdersRepository
    {
        public ShipmentOrdersRepository(Context context)
            :base(context, "api/shipmentorders")
        {
            
        }

        public ShipmentOrder.Summary CreateFastForOrder(long id, long transactionId, CreateShipmentOrderArgs args)
        {
            return this.context.CreateShipmentOrderFastForOrder(id, transactionId, args);
        }

        public string GetLabel(long id, ShipmentLabelType type = ShipmentLabelType.Shipment)
        {
            return this.context.GetShipmentOrderLabel(id, type);
        }
    }
}