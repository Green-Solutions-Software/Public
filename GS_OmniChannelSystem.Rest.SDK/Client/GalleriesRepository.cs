using GS.OmniChannelSystem.Rest.SDK.Models;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class GalleriesRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Gallery, GS.OmniChannelSystem.Rest.SDK.Models.Gallery.Summary>, IGalleriesRepository
    {
        public GalleriesRepository(Context context)
            :base(context, "api/galleries")
        {
            
        }

        public Gallery GetByKey(string key)
        {
            return this.context.GetGalleryByKey(key);
        }
    }
}