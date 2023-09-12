using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class TeasersRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Teaser, GS.OmniChannelSystem.Rest.SDK.Models.Teaser.Summary>, ITeasersRepository
    {
        public TeasersRepository(Context context)
            :base(context, "api/teasers")
        {
            
        }
    }
}