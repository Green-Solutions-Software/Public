using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Leaflet : SEOMainEntity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long LeafletID { get; set; }
            public string Name { get; set; }

            public string GetDisplayName(long languageID)
            {
                return this.Name;
            }
        }

        public Leaflet()
        {
        }

        public long LeafletID { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public List<EntityReference> Tags { get; set; }
        public List<LeafletPhoto> Photos { get; set; }
        public List<LeafletAttachment> Attachments { get; set; }
        public int? Order { get; set; }
        public bool Inactive { get; set; }
    }
}
