using GS.Cordoba.Rest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class GallerySlide : Entity
    {
        public long GallerySlideID { get; set; }
        public int Index { get; set; }
        public PictureEntityReference PlantPicture { get; set; }
        public EntityReference Video { get; set; }
        public EntityReference Container { get; set; }
        public List<EntityReference> Tags { get; set; } // m:n
        public List<EntityReference> Categories { get; set; } // m:n
        public List<EntityReference> PlantColors { get; set; } // m:n
        public string Link { get; set; }
        public PictureEntityReference OverlayPicture { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LinkText { get; set; }


    }
}
