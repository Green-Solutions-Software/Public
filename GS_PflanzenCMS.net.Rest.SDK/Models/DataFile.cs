using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class DataFile : File
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long FileID { get; set; }
            public int Revision { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public long Size { get; set; }
        }

    }
}
