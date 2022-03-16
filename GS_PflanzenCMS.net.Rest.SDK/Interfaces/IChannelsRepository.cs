using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Interfaces
{
    public interface IChannelsRepository : IRepository<GS.PflanzenCMS.Rest.SDK.Models.Channel, GS.PflanzenCMS.Rest.SDK.Models.Channel.Summary>
    {
        Channel GetMonitor(Models.Channel value);
        Dialog GetMonitorPlayer(long id);
        Paginated<GallerySlide> FindMonitorSlides(long id, int pageIndex = 0, int pageSize = 100);
    }
}

