using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class File : Entity
    {

        public long FileID { get; set; }
        public int Revision { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid Guid { get; set; }

        public string Url { get; set; }

        public string SmallUrl { get; set; }

        public string MediumUrl { get; set; }

        public string LargeUrl { get; set; }

        public long Size { get; set; }
        public string Title { get; set; }
        public string SearchKeywords { get; set; }

        public string Storename { get; set; }
        public string StoreName200x200ProportionalBiggest { get; set; }
        public string StoreName600x600ProportionalBiggest { get; set; }
        public string StoreName1200x1200ProportionalBiggest { get; set; }
        public int? FrameCount { get; set; }
        public string StoreNameFrames { get; set; }
        public string StoreNameFramesMedium { get; set; }

    }
}
