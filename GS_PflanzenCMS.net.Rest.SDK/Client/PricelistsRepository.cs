﻿using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class PricelistsRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Pricelist, GS.PflanzenCMS.Rest.SDK.Models.Pricelist.Summary>, IPricelistsRepository
    {
        public PricelistsRepository(Context context)
            :base(context, "api/pricelists")
        {
            
        }
    }
}