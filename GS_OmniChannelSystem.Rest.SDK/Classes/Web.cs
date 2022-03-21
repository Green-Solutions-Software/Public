using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GS.OmniChannelSystem.Rest.SDK.Classes
{
    public class Web
    {
        public static string Combine(string endpoint, string resource)
        {
            if (!endpoint.EndsWith("/"))
                endpoint += "/";
            return endpoint + resource;
        }
    }
}
