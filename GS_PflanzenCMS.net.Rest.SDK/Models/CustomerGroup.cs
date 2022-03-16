using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class CustomerGroup : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long CustomerGroupID { get; set; }
            public string Name { get; set; }
            public virtual string Key { get; set; }
        }

        public long CustomerGroupID { get; set; }
        public string Name { get; set; }
        public virtual string Key { get; set; }
    }
}
