﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class SequenceItem : Entity
    {
        public long SequenceItemID { get; set; }
        public long Value { get; set; }
        public string Number { get; set; }
        public string Key { get; set; }
    }
}