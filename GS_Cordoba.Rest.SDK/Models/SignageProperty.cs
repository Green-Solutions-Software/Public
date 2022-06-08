using GS.Cordoba.Rest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class SignageProperty : Entity
    {
        public long SignagePropertyID { get; set; }
        public string ContentId { get; set; }
        public string StringValue { get; set; }
        public string DisplayName { get; set; }


    }
}
