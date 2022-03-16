using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class WebsiteTemplate : GS.PflanzenCMS.Rest.SDK.Models.Base
    {
        public class Download : GS.PflanzenCMS.Rest.SDK.Models.Base
        {
            public string Url { get; set; }
        }

        public class Directory : GS.PflanzenCMS.Rest.SDK.Models.Base
        {
            public string RelativePath { get; set; }
            public List<string> Files { get; set; }
        }

        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {

        }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ThumbnailFilePath { get; set; }
        public string Usage { get; set; }
        public string Key { get; set; }
        public string OriginalTemplate { get; set; }
    }
}
