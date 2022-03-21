using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class ResolvedPicto : Entity
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Key { get; set; }
        public string Url { get; set; }
        public long PictoID { get; set; }
    }
}