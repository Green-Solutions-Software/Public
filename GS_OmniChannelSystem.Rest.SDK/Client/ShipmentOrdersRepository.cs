﻿using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;
using GS.OmniChannelSystem.Rest.SDK.Models;

namespace GS.OmniChannelSystem.Rest.SDK.Client
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