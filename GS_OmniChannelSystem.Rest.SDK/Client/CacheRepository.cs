﻿using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class CacheRepository : BaseRepository, ICacheRepository
    {
        public CacheRepository(Context context)
            :base(context)
        {
            
        }

        public void Clear()
        {
            this.context.ClearCache();
        }
    }
}