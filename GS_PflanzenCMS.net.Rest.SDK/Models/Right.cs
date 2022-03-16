using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Right : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long RightID { get; set; }
            public string Name { get; set; }
        }

        public Right()
        {
        }

        public long RightID { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
    }
}
