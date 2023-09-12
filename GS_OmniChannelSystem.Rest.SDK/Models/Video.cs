using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Video : SEOMainEntity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long VideoID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int DurationSeconds { get; set; }
            public VideoPhoto MainPhoto { get; set; }
        }

        public Video()
        {
        }

        public long VideoID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationSeconds { get; set; }
        public VideoPhoto MainPhoto { get; set; }
        public ICollection<EntityReference> Categories { get; set; }
        public ICollection<EntityReference> Tags { get; set; }
        public ICollection<VideoFile> Files { get; set; }
        public ICollection<VideoPhoto> Photos { get; set; }
    }
}
