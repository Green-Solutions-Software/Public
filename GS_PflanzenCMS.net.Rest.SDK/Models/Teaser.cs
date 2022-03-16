using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Teaser : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long TeaserID { get; set; }
            public string Color { get; set; }
            public string Name { get; set; }
            public string Key { get; set; }
        }

        public long TeaserID { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }

    }
}
