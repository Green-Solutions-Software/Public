using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Page : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long PageID { get; set; }
            public string Name { get; set; }
            public string Url { get; set; }
            public string Title { get; set; }
            public string Template { get; set; }

            public string GetDisplayName(long languageID)
            {
                return this.Name;
            }
        }

        public long PageID { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string SEOTitle { get; set; }
        public string TitlePattern { get; set; }
        public string Defaults { get; set; }
        public string Constraints { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Keywords { get; set; }
        public PictureEntityReference Picture { get; set; }
        public EntityReference Parent { get; set; }
        public EntityReference Gallery { get; set; }
        public EntityReference Container { get; set; }
        public EntityReference Background { get; set; }
        public List<PageLinkTarget> LinkTargets { get; set; }
        public List<EntityReference> Roles { get; set; }
        public string MasterView { get; set; }
        public string Template { get; set; }
        public string Content { get; set; }
        public PageStatusType Status { get; set; }

        public string GetDisplayName(long languageID)
        {
            return this.Name;
        }
    }
}
