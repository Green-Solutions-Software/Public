using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Brand : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long BrandID { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }
        }

        public long BrandID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public PictureEntityReference Logo { get; set; }

        public EntityReference Grower { get; set; }
    }
}
