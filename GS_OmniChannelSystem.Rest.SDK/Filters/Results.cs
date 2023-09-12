using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Filters
{
    public class Results : Base
    {
        protected override void addFilter(Dictionary<string, string> dict)
        {
            if (JobID != null)
                dict["jobid"] = ((short)JobID).ToString();

        }

        // Job
        public long? JobID { get; set; }
    }
}
