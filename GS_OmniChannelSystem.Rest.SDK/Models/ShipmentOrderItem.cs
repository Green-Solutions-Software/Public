using System;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class ShipmentOrderItem : Entity
    {
        public long ShipmentOrderItemID { get; set; }
        public string Number { get; set; }

        public EntityReference Transaction { get; set; }
        public EntityReference ShipmentOrder { get; set; }

        public double WeightInKg { get; set; }
        public double? LengthInCM { get; set; }
        public double? WidthInCM { get; set; }
        public double? HeightInCM { get; set; }

        public string Data { get; set; }

        public DateTime? TakenOn { get; set; }
        public DateTime? CancelledOn { get; set; }

        public bool HasShipmentLabel { get; set; }
        public bool HasReturnLabel { get; set; }
        public bool HasExportLabel { get; set; }
        public bool HasCodeLabel { get; set; }

    }
}
