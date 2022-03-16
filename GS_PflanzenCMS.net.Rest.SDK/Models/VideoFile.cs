using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class VideoFile : Entity
    {
        public long VideoFileID { get; set; }
        public EntityReference Language { get; set; }
        public string Name { get; set; }
        public VideoSource Source { get; set; }
        public int Revision { get; set; }
        public string Mp4File { get; set; }
        public string OggFile { get; set; }
        public string WebmFile { get; set; }
        public string FLVFile { get; set; }
        public string UrlMp4 { get; set; }
        public string UrlOgg { get; set; }
        public string UrlWebm { get; set; }
        public string UrlFlv { get; set; }
        public string Url { get; set; }
    }
}