using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Timeline : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long TimelineID { get; set; }
            public string Name { get; set; }
            public int Year { get; set; }
            public string Key { get; set; }
        }

        public long TimelineID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Key { get; set; }
        public ICollection<TimelineItem> Items { get; set; }
    }
}
