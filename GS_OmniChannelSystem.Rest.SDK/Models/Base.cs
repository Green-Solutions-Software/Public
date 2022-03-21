using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    [Serializable]
    public class Base
    {
        [JsonIgnore]
        public object Tag;

    }
}

    