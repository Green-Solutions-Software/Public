using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class FeaturesRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Feature, GS.OmniChannelSystem.Rest.SDK.Models.Feature.Summary>, IFeaturesRepository
    {
        public FeaturesRepository(Context context)
            :base(context, "api/features")
        {
            
        }
    }
}