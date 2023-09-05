using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Gallery : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long GalleryID { get; set; }
            public string Name { get; set; }
            public string Key { get; set; }

            public string GetDisplayName(long languageID)
            {
                return this.Name;
            }
        }

        public long GalleryID { get; set; }
        public string Name { get; set; }
        public string Assignments { get; set; }
        public string Key { get; set; }
        public List<GallerySlide> Photos { get; set; }

        public string GetDisplayName(long languageID)
        {
            return this.Name;
        }
    }
}
