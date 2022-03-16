﻿using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class ChannelsRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Channel, GS.PflanzenCMS.Rest.SDK.Models.Channel.Summary>, IChannelsRepository
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