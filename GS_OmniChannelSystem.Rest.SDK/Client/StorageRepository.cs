using GS.OmniChannelSystem.Rest.SDK.Models;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class StorageRepository : BaseRepository, IStorageRepository
    {
        public StorageRepository(Context context)
            :base(context)
        {
            
        }

        public UrlResult Url(long id, int width = 800, int height = 800)
        {
            return this.context.GetStorageUrl(id, width, height);
        }

    }
}