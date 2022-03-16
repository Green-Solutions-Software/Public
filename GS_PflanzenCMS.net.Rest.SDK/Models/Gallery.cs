using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Gallery : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long GalleryID { get; set; }
            public string Name { get; set; }
            public string Key { get; set; }

            public string GetDisplayName(long languageID)
            {
                return this.Name;
            }
        }

        public long GalleryID { get; set; }
        public string Name { get; set; }
        public string Assignments { get; set; }
        public string Key { get; set; }
        public List<GallerySlide> Photos { get; set; }

        public string GetDisplayName(long languageID)
        {
            return this.Name;
        }
    }
}
