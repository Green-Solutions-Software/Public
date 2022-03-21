﻿using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class PagesRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Page, GS.OmniChannelSystem.Rest.SDK.Models.Page.Summary>, IPagesRepository
    {
        public PagesRepository(Context context)
            :base(context, "api/pages")
        {
            
        }

        public Paginated<GS.OmniChannelSystem.Rest.SDK.Models.Page.Summary> FindAll(long? parentId, string search, int pageIndex, int pageSize, string orderBy)
        {
            return this.context.FindPages(parentId, search, pageIndex, pageSize, orderBy);
        }

    }
}