using GS.Cordoba.Rest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class ContainerItem : Entity
    {
        public long ContainerItemID { get; set; }

        public PictureEntityReference PlantPicture { get; set; }
        public EntityReference Video { get; set; }
        public EntityReference SubContainer { get; set; }
        public List<EntityReference> Tags { get; set; } // m:n
        public List<EntityReference> PlantColors { get; set; } // m:n
        public EntityReference OverlayPicture { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

       
    }
}
