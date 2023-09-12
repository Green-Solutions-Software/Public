using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class WebsiteTemplate : GS.OmniChannelSystem.Rest.SDK.Models.Base
    {
        public class Download : GS.OmniChannelSystem.Rest.SDK.Models.Base
        {
            public string Url { get; set; }
        }

        public class Directory : GS.OmniChannelSystem.Rest.SDK.Models.Base
        {
            public string RelativePath { get; set; }
            public List<string> Files { get; set; }
        }

        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
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
