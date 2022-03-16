using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Api.Args
{
    public class SearchCrossArgs : SearchArgs
    {
        public long? ReportID { get; set; }
        public long? VideoID { get; set; }
        public long? ArticleID { get; set; }
    }
}
