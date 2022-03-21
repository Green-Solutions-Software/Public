using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Api.Args
{
    public class MemberMessageArgs
    {
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
