using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class MailTemplatesRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.MailTemplate, GS.OmniChannelSystem.Rest.SDK.Models.MailTemplate.Summary>, IMailTemplatesRepository
    {
        public MailTemplatesRepository(Context context)
            :base(context, "api/mailtemplates")
        {
            
        }
    }
}