using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Filters
{
    public class Invoices : Base
    {
        protected override void addFilter(Dictionary<string, string> dict)
        {
            if(CreatedOnFrom != null)
            {
                if (CreatedOnTo == null)
                    throw new ArgumentNullException("CreatedOnTo");
                dict["createdon"] = CreatedOnFrom.Value.Ticks.ToString() + "-" + CreatedOnTo.Value.Ticks.ToString();
            }
        }

        public DateTime? CreatedOnFrom { get; set; }
        public DateTime? CreatedOnTo { get; set; }
    }
}
