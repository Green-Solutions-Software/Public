using System;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class ArticleRating : Entity
    {
        public long ArticleRatingID { get; set; }
        public EntityReference Member { get; set; }
        public EntityReference Article { get; set; }
        public EntityReference ArticleKey { get; set; }

        public int Rating { get; set; }
        public string Comment { get; set; }
        public long LanguageID { get; set; }
        public DateTime? Approved { get; set; }
        public EntityReference ApprovedBy { get; set; }
    }
}