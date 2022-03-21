using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Filters
{
    public class Base
    {
        protected virtual void addFilter(Dictionary<string,string> dict)
        {

        }

        public override string ToString()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            addFilter(dict);
            StringBuilder sb = new StringBuilder();
            foreach(var d in dict)
            {
                if (sb.Length > 0)
                    sb.Append(";");
                sb.Append(d.Key + "|" + d.Value);
            }

            return sb.ToString();
        }

    }
}
