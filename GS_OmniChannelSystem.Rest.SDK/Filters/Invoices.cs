using System;
using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Filters
{
    public class Invoices : Base
    {
        protected override void addFilter(Dictionary<string, string> dict)
        {
            if(CreatedOnFrom != null)
            {
                if (CreatedOnTo == null)
                    throw new ArgumentNullException("CreatedOnTo");
                dict["createdon"] = CreatedOnFrom.Value.Ticks.ToString() + "-" + CreatedOnTo.Value.Ticks.ToString();
            }
        }

        public DateTime? CreatedOnFrom { get; set; }
        public DateTime? CreatedOnTo { get; set; }
    }
}
