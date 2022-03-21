using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Feature : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long FeatureID { get; set; }
            public virtual string Name { get; set; }
            public virtual string Key { get; set; }
        }

        public long FeatureID { get; set; }
        public string Name { get; set; }
        public FeatureEnumType Type { get; set; }
        public EntityReference FeatureType { get; set; }
        public List<EntityReference> Features { get; set; }
        public string Key { get; set; }
        public string Color { get; set; }

    }
}
