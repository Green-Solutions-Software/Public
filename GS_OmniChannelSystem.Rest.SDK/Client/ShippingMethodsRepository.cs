using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class ShippingMethodsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.ShippingMethod, GS.OmniChannelSystem.Rest.SDK.Models.ShippingMethod.Summary>, IShippingMethodsRepository
    {
        public ShippingMethodsRepository(Context context)
            :base(context, "api/shippingmethods")
        {
            
        }
    }
}