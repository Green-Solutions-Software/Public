using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Role : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long RoleID { get; set; }
            public string Name { get; set; }
            public string Key { get; set; }
        }

        public Role()
        {
        }

        public long RoleID { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public List<EntityReference> Rights { get; set; }
        public List<EntityReference> Roles { get; set; }
    }
}
