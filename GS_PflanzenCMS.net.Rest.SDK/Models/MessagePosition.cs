﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class MessagePosition : Entity
    {
        public long MessagePositionID { get; set; }
        public string External_Data { get; set; }
        public EntityReference OrderItem { get; set; }
        public EntityReference Message { get; set; }
        public int? Quantity { get; set; }
        public string Notes { get; set; }
        public ReturnReason? ReturnReason { get; set; }
    }
}
