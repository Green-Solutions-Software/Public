using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class CalendarItem : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long CalendarItemID { get; set; }
            public string Title { get; set; }
            public string ShortDescription { get; set; }
            public DateTime StartingDate { get; set; }
            public DateTime EndDate { get; set; }
            public PictureEntityReference Picture { get; set; }
        }

        public long CalendarItemID { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<EntityReference> Countries { get; set; }
        public List<EntityReference> Tags { get; set; }
        public PictureEntityReference Picture { get; set; }
        public List<Attachment> Attachments { get; set; }
        public Interval Interval { get; set; }
        public string Link { get; set; }
        public bool Inactive { get; set; }

    }
}
