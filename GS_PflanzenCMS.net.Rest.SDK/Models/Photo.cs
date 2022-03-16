using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Photo : Entity
    {
        public long PhotoID { get; set; }
        public PictureEntityReference Picture { get; set; }
        public EntityReference Language { get; set; }
        public string Title { get; set; }
        public PictureDisplayMode DisplayMode { get; set; }
        public int Priority { get; set; }
    }

}
