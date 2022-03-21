using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class LeafletsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Leaflet, GS.OmniChannelSystem.Rest.SDK.Models.Leaflet.Summary>, ILeafletsRepository
    {
        public LeafletsRepository(Context context)
            :base(context, "api/leaflets")
        {
            
        }
    }
}