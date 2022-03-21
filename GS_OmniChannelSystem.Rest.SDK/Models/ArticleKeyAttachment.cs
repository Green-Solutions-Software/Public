using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class ArticleKeyAttachment : Attachment
    {
        public DataFileEntityReference DataFile { get; set; }
    }
}
