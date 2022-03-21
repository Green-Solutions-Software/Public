using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IChannelsRepository : IRepository<GS.OmniChannelSystem.Rest.SDK.Models.Channel, GS.OmniChannelSystem.Rest.SDK.Models.Channel.Summary>
    {
        Channel GetMonitor(Models.Channel value);
        Dialog GetMonitorPlayer(long id);
        Paginated<GallerySlide> FindMonitorSlides(long id, int pageIndex = 0, int pageSize = 100);
    }
}

