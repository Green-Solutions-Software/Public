using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class LeafletsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Leaflet, GS.OmniChannelSystem.Rest.SDK.Models.Leaflet.Summary>, ILeafletsRepository
    {
        public LeafletsRepository(Context context)
            :base(context, "api/leaflets")
        {
            
        }
    }
}