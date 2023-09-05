using System;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Payment : Entity
    {
        public long PaymentID { get; set; }

        public DateTime? ReservedUntil { get; set; }
        public string Info { get; set; }
        public double Price { get; set; }
        public EntityReference Currency { get; set; }
        public VoucherCode VoucherCode { get; set; }
        public EntityReference PaymentMethod { get; set; }
    }
}