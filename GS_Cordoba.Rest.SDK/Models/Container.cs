using System.Collections.Generic;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class Container : MainEntity
    {
        public class Summary : Models.Summary
        {
            public long ContainerID { get; set; }
            public virtual string Name { get; set; }
            public virtual string Key { get; set; }
        }

        public long ContainerID { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }

        public List<ContainerItem> Items { get; set; }

    }
}
