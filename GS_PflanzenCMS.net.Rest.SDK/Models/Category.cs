using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Category : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public Summary()
            {

            }

            public Summary(Category other)
            {
                this.Name = other.Name;
            }

            public long CategoryID { get; set; }
            public virtual string Name { get; set; }
            public virtual string Key { get; set; }
        }

        public long CategoryID { get; set; }
        public string Key { get; set; }
        public string Notes { get; set; }
        public int? Order { get; set; }
        public bool Inactive { get; set; }
        public string Name { get; set; }
        public EntityReference Parent { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public List<CategoryPhoto> Photos { get; set; }
        public EntityReference Container { get; set; }
    }
}
