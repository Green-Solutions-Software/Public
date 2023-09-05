using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class TimelinesRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Timeline, GS.OmniChannelSystem.Rest.SDK.Models.Timeline.Summary>, ITimelinesRepository
    {
        public TimelinesRepository(Context context)
            :base(context, "api/timelines")
        {
            
        }
    }
}