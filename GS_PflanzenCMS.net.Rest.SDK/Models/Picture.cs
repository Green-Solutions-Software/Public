using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Picture : DataFile
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long FileID { get; set; }
            public int Revision { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public long Size { get; set; }
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public float DpiX { get; set; }
        public float DpiY { get; set; }
        public string Type { get; set; }
        public PictureType PictureType { get; set; }

    }
}
