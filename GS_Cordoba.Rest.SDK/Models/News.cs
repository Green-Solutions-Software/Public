using System;
using System.Collections.Generic;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class News : MainEntity
    {
        public class Summary : Models.Summary
        {
            public long NewsID { get; set; }
            public string Title { get; set; }
            public string ShortDescription { get; set; }
            public PictureEntityReference Picture { get; set; }
            public string Link { get; set; }
        }

        public long NewsID { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Content { get; set; }

        public Contact Contact { get; set; }

        public bool Published { get; set; }

        public List<EntityReference> Tags { get; set; }

        public DateTime Date { get; set; }

        public PictureEntityReference Picture { get; set; }

        public string Link { get; set; }

    }
}
