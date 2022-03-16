using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class GallerySlide : Entity
    {
        public long GallerySlideID { get; set; }
        public GallerySlideType Type { get; set; }
        public PictureEntityReference Picture { get; set; }
        public ImageRect PictureRect { get; set; }
        public PictureEntityReference OverlayPicture { get; set; }
        public EntityReference Video { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string TabDescription { get; set; }
        public string Description { get; set; }
        public EntityReference Page { get; set; }
        public string Parameters { get; set; }
        public EntityReference Teaser { get; set; }
        public EntityReference Category { get; set; }
        public string ExternalUrl { get; set; }
        public bool Inactive { get; set; }
        public string PageButtonText { get; set; }
        public long Index { get; set; }
        public List<GallerySlideAttachment> Attachments { get; set; }
             

    }
}
