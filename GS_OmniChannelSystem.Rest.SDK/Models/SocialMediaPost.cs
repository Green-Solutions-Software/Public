using System;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class SocialMediaPost : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long SocialMediaPostID { get; set; }
            public string Message { get; set; }

            public string GetDisplayName(long languageID)
            {
                return this.Message;
            }
        }

        public long SocialMediaPostID { get; set; }
        public EntityReference News { get; set; }
        public EntityReference Video { get; set; }
        public EntityReference Report { get; set; }
        public EntityReference Article { get; set; }
        public string Message { get; set; }
        public DateTime? SendOn { get; set; }
        public DateTime? ProcessedOn { get; set; }
        public bool PostDirectly { get; set; }
    }
}
