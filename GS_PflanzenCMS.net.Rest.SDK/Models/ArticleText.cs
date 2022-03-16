using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class ArticleText : Entity
    {
        public long ArticleTextID { get; set; }
        public short Position { get; set; }
        public TextType Type { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
    }
}