using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Media : Entity
    {
        public long MediaID { get; set; }
        public EntityReference Video { get; set; }
        public EntityReference Language { get; set; }
        public string Title { get; set; }
    }

}
