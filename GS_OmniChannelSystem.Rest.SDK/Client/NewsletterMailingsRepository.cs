using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class NewsletterMailingsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.NewsletterMailing, GS.OmniChannelSystem.Rest.SDK.Models.NewsletterMailing.Summary>, INewsletterMailingRepository
    {
        public NewsletterMailingsRepository(Context context)
            :base(context, "api/newslettermailings")
        {
            
        }
    }
}