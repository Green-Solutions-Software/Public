using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Result : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long ResultID { get; set; }
            public string Text { get; set; }
            public string ResultType { get; set; }
            public string Stacktrace { get; set; }
        }

        public long ResultID { get; set; }
        public string Text { get; set; }
        public string ResultType { get; set; }
        public string Stacktrace { get; set; }
        public EntityReference File { get; set; }
        public EntityReference Language { get; set; }



    }
}
