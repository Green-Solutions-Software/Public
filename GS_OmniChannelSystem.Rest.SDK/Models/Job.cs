using System;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Job : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long JobID { get; set; }
            public string Name { get; set; }
            public double? Percent { get; set; }
            public string Status { get; set; }
        }

        public long JobID { get; set; }
        public string Name { get; set; }
        public double? Percent { get; set; }
        public string Status { get; set; }
        public string Parameter { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Finished { get; set; }
        public DateTime? Alive { get; set; }
        public DateTime? Aborted { get; set; }
        public bool? Succeeded { get; set; }
        public int? ErrorCount { get; set; }
        public int? InfoCount { get; set; }
        public int? WarningCount { get; set; }
        public int? DownloadCount { get; set; }
        public int? ResultCount { get; set; }

      
    }
}
