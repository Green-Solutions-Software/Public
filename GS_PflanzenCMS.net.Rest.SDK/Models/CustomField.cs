﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class CustomField : Entity
    {
        public long CustomFieldID { get; set; }
        public EntityReference Field { get; set; }
        public string StringValue { get; set; }
        public int? IntValue { get; set; }
        public DateTime? DateValue { get; set; }
        public double? FloatValue { get; set; }
        public bool? BoolValue { get; set; }
    }
}