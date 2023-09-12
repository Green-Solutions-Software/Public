using System.Collections.Generic;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class Video : MainEntity
    {
        public class Summary : Models.Summary
        {
            public long VideoID { get; set; }
            public virtual string Name { get; set; }
            public virtual string Description { get; set; }
            public int DurationSeconds { get; set; }
            public List<EntityReference> Tags { get; set; }

            public PictureEntityReference MainPicture { get; set; }
        }

        public long VideoID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public int DurationSeconds { get; set; }
        public PriorityType? Priority { get; set; }
        public ICollection<EntityReference> Categories { get; set; }
        public ICollection<EntityReference> Tags { get; set; }
        public ICollection<VideoFile> Files { get; set; }
        public ICollection<VideoPhoto> Photos { get; set; }

    }
}
