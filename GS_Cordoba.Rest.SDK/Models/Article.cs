using GS.Cordoba.Rest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ObservableCollection<EntityReference> Members { get; set; }

        public ObservableCollection<ArticlePhoto> Photos { get; set; }
        public ObservableCollection<EntityReference> ArticleGroups { get; set; }
        public ObservableCollection<EntityReference> Categories { get; set; }
        public ObservableCollection<ArticleText> Texts { get; set; } // n:1
        public ObservableCollection<EntityReference> Tags { get; set; }
        public ObservableCollection<EntityReference> Features { get; set; }
        public string BotanicName { get; set; }
        public string NameTranslation { get; set; }

    }
}
