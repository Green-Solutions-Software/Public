﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Channel : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long ChannelID { get; set; }
            public virtual string Name { get; set; }
            public ChannelType Type { get; set; }
            public virtual EntityReference MarketPlace { get; set; }
        }

        public long ChannelID { get; set; }
        public ChannelType Type { get; set; }
        public virtual string Name { get; set; }
        public bool Relay { get; set; }
        public string DatabaseSetup { get; set; }
        public string ConnectionString { get; set; }
        public string Revision { get; set; }
        public virtual EntityReference MarketPlace { get; set; }
    }
}
