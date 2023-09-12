using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Role : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
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
