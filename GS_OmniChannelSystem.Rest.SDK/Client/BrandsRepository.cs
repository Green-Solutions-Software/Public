using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class BrandsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Brand, GS.OmniChannelSystem.Rest.SDK.Models.Brand.Summary>, IBrandsRepository
    {
        public BrandsRepository(Context context)
            :base(context,"api/brands")
        {
            
        }

    }
}