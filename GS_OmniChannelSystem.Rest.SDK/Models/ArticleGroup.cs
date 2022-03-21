using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class ArticleGroup : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long ArticleGroupID { get; set; }
            public string Name { get; set; }
            public EntityReference Parent { get; set; }
            public string Number { get; set; }
        }

        public long ArticleGroupID { get; set; }
        public string Name { get; set; }
        public EntityReference Parent { get; set; }
        public string Number { get; set; }
        public int? BaseStock { get; set; }
        public List<ArticleGroupProperty> Properties { get; set; }
        public List<ArticleGroupProperty> PropertiesEx { get; set; }
        public string AvailableForShippingText { get; set; } // Ausliefern
        public DeliverTime AvailableForShippingDeliverTime { get; set; } // Ausliefern Time
        public string AvailableForRadiusDeliveryText { get; set; } // Im Umkreis ausliefern
        public DeliverTime AvailableForRadiusDeliveryDeliverTime { get; set; } // Im Umkreis ausliefern Time
        public string AvailableForClickAndCollectText { get; set; } // Click & Collect
        public DeliverTime AvailableForClickAndCollectDeliverTime { get; set; } // Click & Collect Time
    }
}
