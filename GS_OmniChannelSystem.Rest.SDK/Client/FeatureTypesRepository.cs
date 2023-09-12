using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class FeatureTypesRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.FeatureType, GS.OmniChannelSystem.Rest.SDK.Models.FeatureType.Summary>, IFeatureTypesRepository
    {
        public FeatureTypesRepository(Context context)
            :base(context, "api/featuretypes")
        {
            
        }

    }
}