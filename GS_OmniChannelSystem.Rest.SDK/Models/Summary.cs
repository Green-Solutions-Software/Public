using System;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Summary : Base
    {
        public DateTime CreatedOn { get; set; }
        public string External_Key { get; set; }
        public string External_RowVersion { get; set; }
        public string RowVersion { get; set; }
    }

}
