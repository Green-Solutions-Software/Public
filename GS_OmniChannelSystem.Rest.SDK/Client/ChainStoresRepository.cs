using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class ChainStoresRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.ChainStore, GS.OmniChannelSystem.Rest.SDK.Models.ChainStore.Summary>, IChainStoresRepository
    {
        public ChainStoresRepository(Context context)
            :base(context, "api/chainstores")
        {
            
        }

    }
}