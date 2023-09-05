using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class ChainStoresRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.ChainStore, GS.OmniChannelSystem.Rest.SDK.Models.ChainStore.Summary>, IChainStoresRepository
    {
        public ChainStoresRepository(Context context)
            :base(context, "api/chainstores")
        {
            
        }

    }
}