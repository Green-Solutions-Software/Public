﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Pricelist : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long PricelistID { get; set; }
            public string Name { get; set; }
        }

        public long PricelistID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string Key { get; set; }
        public string Color { get; set; }
        public int? Priority { get; set; }
        public bool Public { get; set; }

        public List<PricelistItem> Items { get; set; }
        public List<EntityReference> CustomerGroups { get; set; }
        public List<EntityReference> Members { get; set; }
    }
}
