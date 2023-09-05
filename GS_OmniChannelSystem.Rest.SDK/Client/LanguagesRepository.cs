using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class LanguagesRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Language, GS.OmniChannelSystem.Rest.SDK.Models.Language.Summary>, ILanguagesRepository
    {
        public LanguagesRepository(Context context)
            :base(context, "api/languages")
        {
            
        }
    }
}