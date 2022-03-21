using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class MailTemplate : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long MailTemplateID { get; set; }
            public string Key { get; set; }
            public string Subject { get; set; }
        }

        public MailTemplate()
        {
        }

        public long MailTemplateID { get; set; }
        public string Key { get; set; }
        public string MasterView { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public string PreviewText { get; set; }
        public List<MailTemplateAttachment> Attachments { get; set; }
    }
}
