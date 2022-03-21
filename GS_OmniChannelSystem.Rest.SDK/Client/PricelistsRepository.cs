using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class PricelistsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Pricelist, GS.OmniChannelSystem.Rest.SDK.Models.Pricelist.Summary>, IPricelistsRepository
    {
        public PricelistsRepository(Context context)
            :base(context, "api/pricelists")
        {
            
        }
    }
}