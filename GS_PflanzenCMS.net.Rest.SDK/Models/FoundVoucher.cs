﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class FoundVoucher : Base
    {
        public long VoucherID { get; set; }
        public long VoucherCodeID { get; set; }
        public DateTime? UsedOn { get; set; }
        public string KeyValue { get; set; }
        public string EAN { get; set; }
        public double Remaining { get; set; }
        public EntityReference Currency { get; set; }
                     
    }
}