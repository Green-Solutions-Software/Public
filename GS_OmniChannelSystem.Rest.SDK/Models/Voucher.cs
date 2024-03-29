﻿using System;
using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Voucher : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long VoucherID { get; set; }
            public string Name { get; set; }
            public DateTime? ValidFrom { get; set; }
            public DateTime? ValidTo { get; set; }
            public string KeyValue { get; set; }
        }


        public long VoucherID { get; set; }
        public string Name { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public string KeyValue { get; set; }
        public VoucherType Type { get; set; }
        public EntityReference OrderItem { get; set; }
        public double Price { get; set; }
        public double Remaining { get; set; }
        public string Info { get; set; }
        public EntityReference Currency { get; set; }
        public List<VoucherCode> Codes { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
