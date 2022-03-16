using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Summary : Base
    {
        public DateTime CreatedOn { get; set; }
        public string External_Key { get; set; }
        public string External_RowVersion { get; set; }
        public string RowVersion { get; set; }
    }

}
