using System;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class VoucherCode : Entity
    {
        public long VoucherCodeID { get; set; }
        public DateTime? UsedOn { get; set; }
        public string KeyValue { get; set; }
        public string EAN { get; set; }
        public virtual EntityReference Voucher { get; set; }
    }
}