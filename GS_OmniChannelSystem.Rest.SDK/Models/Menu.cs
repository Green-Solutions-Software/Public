using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Menu : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
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
