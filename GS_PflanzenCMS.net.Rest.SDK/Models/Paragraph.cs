using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Paragraph : Entity
    {
        public long ParagraphID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public EntityReference Picture { get; set; }
        public short Position { get; set; }
        public List<ParagraphPhoto> Photos { get; set; }
        public List<ParagraphMedia> Medias { get; set; }
        public EntityReference Report { get; set; }
        public ParagraphType Type { get; set; }
             

    }
}
