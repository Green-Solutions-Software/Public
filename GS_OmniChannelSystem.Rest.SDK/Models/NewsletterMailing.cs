using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class NewsletterMailing : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long NewsletterMailingID { get; set; }
            public string Name { get; set; }
            public string ShortDescription { get; set; }

            public string GetDisplayName(long languageID)
            {
                return this.Name;
            }
        }

        public long NewsletterMailingID { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public EntityReference Template { get; set; }
        public List<NewsletterTemplateAttachment> Attachments { get; set; }
        public List<EntityReference> Groups { get; set; }
        public List<CustomField> Fields { get; set; }
        public string MasterView { get; set; }
        public string ServiceProvider { get; set; }
        public string ServiceProviderData { get; set; }
    }
}
