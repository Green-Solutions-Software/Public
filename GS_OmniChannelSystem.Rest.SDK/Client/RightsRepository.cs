using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class RightsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Right, GS.OmniChannelSystem.Rest.SDK.Models.Right.Summary>, IRightsRepository
    {
        public RightsRepository(Context context)
            :base(context, "api/rights")
        {
            
        }
    }
}