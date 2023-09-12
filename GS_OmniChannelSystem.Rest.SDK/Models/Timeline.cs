using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Timeline : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long TimelineID { get; set; }
            public string Name { get; set; }
            public int Year { get; set; }
            public string Key { get; set; }
        }

        public long TimelineID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Key { get; set; }
        public ICollection<TimelineItem> Items { get; set; }
    }
}
