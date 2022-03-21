using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class TimelineItem : Entity
    {
        public long TimelineItemID { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public EntityReference Article { get; set; }
        public EntityReference Report { get; set; }
        public EntityReference Video { get; set; }
        public EntityReference Leaflet { get; set; }

        public string Title { get; set; }
        public string Title2 { get; set; }
        public long? PictureID { get; set; }

        public string PictureSmall { get; set; }
        public string PictureMedium { get; set; }
        public string PictureLarge { get; set; }
        public string Details { get; set; }
    }
}
