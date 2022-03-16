﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Language : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long LanguageID { get; set; }
            public virtual string ISO { get; set; }
            public virtual string Name { get; set; }
        }

        public long LanguageID { get; set; }
        public string ISO { get; set; }
        public bool Online { get; set; }
        public string Name { get; set; }
        public List<EntityReference> Countries { get; set; }
        public List<TaxRate> TaxRates { get; set; }
    }
}
