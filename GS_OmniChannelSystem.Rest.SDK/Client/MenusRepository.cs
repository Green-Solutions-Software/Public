﻿using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class MenusRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Menu, GS.OmniChannelSystem.Rest.SDK.Models.Menu.Summary>, IMenusRepository
    {
        public MenusRepository(Context context)
            :base(context, "api/menus")
        {
            
        }
    }
}