using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class ShippingMethodsRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.ShippingMethod, GS.PflanzenCMS.Rest.SDK.Models.ShippingMethod.Summary>, IShippingMethodsRepository
    {
        public ShippingMethodsRepository(Context context)
            :base(context, "api/shippingmethods")
        {
            
        }
    }
}