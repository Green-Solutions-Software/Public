using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Api.Args
{
    public class UploadArgs
    {
        public string Filename { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public int Rotation { get; set; }
    }
}
