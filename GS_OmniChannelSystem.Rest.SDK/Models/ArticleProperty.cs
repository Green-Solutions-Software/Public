using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class ArticleProperty : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long ArticlePropertyID { get; set; }
            public ArticlePropertyType Type { get; set; }
            public string Name { get; set; }
            public string Key { get; set; }
        }

        public long ArticlePropertyID { get; set; }
        public ArticlePropertyType Type { get; set; }
        public string Name { get; set; }
        public string Hint { get; set; }
        public string RequiredMessage { get; set; }
        public string Key { get; set; }
        public string Width { get; set; }
        public EntityReference Field { get; set; }
    }
}
