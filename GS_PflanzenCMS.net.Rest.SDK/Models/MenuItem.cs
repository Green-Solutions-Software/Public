using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class MenuItem : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long MenuItemID { get; set; }
            public string Name { get; set; }
        }

        public long MenuItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Anker { get; set; }
        public string Key { get; set; }
        
        public string ExternalUrl { get; set; }
        public EntityReference Page { get; set; }
        public string Parameters { get; set; }
        public string Assignments { get; set; }
        public EntityReference Menu { get; set; } // n:1
        public long Index { get; set; }
        public EntityReference Picture { get; set; }
        public EntityReference Category { get; set; }
        public EntityReference Article { get; set; }
        public EntityReference Report { get; set; }
        public EntityReference Producer { get; set; }
        public EntityReference Tag { get; set; }
        public string CategoryForType { get; set; }
        public List<EntityReference> ContainerItems { get; set; }
        public EntityReference Container { get; set; }
        public string Glyph { get; set; }
        public List<MenuItem> Items { get; set; }

        public List<MenuItem> AllItems
        {
            get
            {
                var result = new List<MenuItem>();
                result.AddRange(this.Items);
                foreach (var item in this.Items)
                    result.AddRange(item.AllItems);
                return result;
            }
        }
    }
}
