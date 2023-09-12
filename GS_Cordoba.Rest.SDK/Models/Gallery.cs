using System.Collections.Generic;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class Gallery : MainEntity
    {
        public class Summary : Models.Summary
        {
            public long GalleryID { get; set; }
            public string Name { get; set; }
            public string Key { get; set; }
        }

        public long GalleryID { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public virtual ICollection<GallerySlide> Slides { get; set; }

    }
}
