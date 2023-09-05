using GS.OmniChannelSystem.Rest.SDK.Models;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class ChannelsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Channel, GS.OmniChannelSystem.Rest.SDK.Models.Channel.Summary>, IChannelsRepository
    {
        public ChannelsRepository(Context context)
            :base(context,"api/channels")
        {
            
        }

        public Channel GetMonitor(Models.Channel value)
        {
            return this.context.GetMonitor(value);
        }

        public Paginated<GallerySlide> FindMonitorSlides(long id, int pageIndex = 0, int pageSize = 100)
        {
            return this.context.FindMonitorSlides(id, pageIndex, pageSize);
        }

        public Dialog GetMonitorPlayer(long id)
        {
            return this.context.GetMonitorPlayer(id);
        }
    }
}