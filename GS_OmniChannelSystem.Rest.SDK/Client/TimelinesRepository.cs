using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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