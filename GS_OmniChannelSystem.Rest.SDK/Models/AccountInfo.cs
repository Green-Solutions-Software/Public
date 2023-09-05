using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class AccountInfo : Base
    {
        public long MemberID { get; set; }
        public long UserID { get; set; }
        public string Member { get; set; }
        public string User { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
        public string Error { get; set; }
        public string Version { get; set; }
        public string PublishDate { get; set; }
        public PictureEntityReference Logo { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Rights { get; set; }
    }
}