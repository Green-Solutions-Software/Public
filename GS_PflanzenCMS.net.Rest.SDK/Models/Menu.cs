using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Menu : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long MenuID { get; set; }
            public string Name { get; set; }
            public string Key { get; set; }
            public bool Active { get; set; }

            public string GetDisplayName(long languageID)
            {
                return this.Name;
            }
        }

        public long MenuID { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }
        public string Key { get; set; }
        public bool Active { get; set; }
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

        public string GetDisplayName(long languageID)
        {
            return this.Name;
        }
    }
}
