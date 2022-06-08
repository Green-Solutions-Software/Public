using GS.Cordoba.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class ArticleText : MainEntity
    {
        public long ArticleTextID { get; set; }
        public short Position { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public TextType Type { get; set; }
    }
}
