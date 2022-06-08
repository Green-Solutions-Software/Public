using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class AccountInfo
    {
        public long MemberID { get; set; }
        public long UserID { get; set; }
        public string Member { get; set; }
        public string User { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
        public string Error { get; set; }
        public string[] Roles { get; set; }
        public string[] Rights { get; set; }
    }
}
