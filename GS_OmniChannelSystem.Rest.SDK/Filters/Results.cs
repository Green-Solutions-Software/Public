using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
