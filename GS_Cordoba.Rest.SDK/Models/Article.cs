using System.Collections.Generic;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class Article : MainEntity
    {
        public class Summary : Models.Summary
        {
            public long ArticleID { get; set; }
            public string Name { get; set; }
            public string Name2 { get; set; }
            public string Description { get; set; }
        }

        public long ArticleID { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public List<EntityReference> Members { get; set; }

        public List<ArticlePhoto> Photos { get; set; }
        public List<EntityReference> ArticleGroups { get; set; }
        public List<EntityReference> Categories { get; set; }
        public List<ArticleText> Texts { get; set; } // n:1
        public List<EntityReference> Tags { get; set; }
        public List<EntityReference> Features { get; set; }
        public string BotanicName { get; set; }
        public string NameTranslation { get; set; }

    }
}
