using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class News : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long NewsID { get; set; }

            public string Title { get; set; }

            public string ShortDescription { get; set; }

            public DateTime Date { get; set; }

            public string ExternalUrl { get; set; }

            public PictureEntityReference Picture { get; set; }

            public bool Published { get; set; }

            public string Url { get; set; }

        }

        public long NewsID { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Content { get; set; }

        public string ExternalUrl { get; set; }
        public PictureDisplayMode? PictureDisplayMode { get; set; }

        public bool Published { get; set; }

        public DateTime Date { get; set; }
        public DateTime? DateTo { get; set; }

        public PictureEntityReference Picture { get; set; }
        public ImageRect PictureRect { get; set; }

        public List<NewsAttachment> Attachments { get; set; }
        public List<EntityReference> Categories { get; set; }
        public List<EntityReference> Tags { get; set; }

        public string Url { get; set; }

    }
}
