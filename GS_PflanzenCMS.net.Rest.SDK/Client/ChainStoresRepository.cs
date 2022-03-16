﻿using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class ChainStoresRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.ChainStore, GS.PflanzenCMS.Rest.SDK.Models.ChainStore.Summary>, IChainStoresRepository
    {
        public ChainStoresRepository(Context context)
            :base(context, "api/chainstores")
        {
            
        }

    }
}