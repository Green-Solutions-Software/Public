using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{

    public class SEOMainEntity : MainEntity
    {
        public string SEOTitle { get; set; }
        public string SEODescription { get; set; }
        public string Keywords { get; set; }
        public ChangeFrequency SeoChangeFrequency { get; set; }
        public double? SeoPriority { get; set; }
        public bool SitemapHide { get; set; }
        public string OGTitle { get; set; }
        public string OGDescription { get; set; }
        public PictureEntityReference OGPicture { get; set; }
        public string SEOFocusKeyword { get; set; }
        public MetaRobotIndex? SEOMetaRobotIndex { get; set; }
        public MetaRobotFollow? SEOMetaRobotFollow { get; set; }
        public MetaRobotAdvanced? SEOMetaRobot { get; set; }
        public string SEOCanonicalUrl { get; set; }
    }
}
