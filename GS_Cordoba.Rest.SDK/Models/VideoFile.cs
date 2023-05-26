using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class VideoFile : Entity
    {
        public long VideoFileID { get; set; }
        public EntityReferenceWithISO Language { get; set; }
        public EntityReference Owner { get; set; }
        public int? Revision { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
        public string OggFile { get; set; }
        public string Mp4File { get; set; }
        public string WebmFile { get; set; }
        public string FLVFile { get; set; }
    }
}
