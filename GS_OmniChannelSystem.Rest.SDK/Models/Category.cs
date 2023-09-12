using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Category : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
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
