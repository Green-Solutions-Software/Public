using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class ArticleTask : Entity
    {
        public long ArticleTaskID { get; set; }
        public EntityReference Task { get; set; }
        public int? FromMonth { get; set; }
        public int? ToMonth { get; set; }
    }
}