using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class Language : MainEntity
    {
        public class Summary : Models.Summary
        {
            public long LanguageID { get; set; }

            public string Name { get; set; }
            public string ISO { get; set; }

            public string GetDisplayName(long languageID)
            {
                return this.Name;
            }
        }

        public long LanguageID { get; set; }

        public string Name { get; set; }
        public string ISO { get; set; }
    }
}
