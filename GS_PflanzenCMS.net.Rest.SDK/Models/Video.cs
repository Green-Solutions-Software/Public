using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Video : SEOMainEntity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
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
