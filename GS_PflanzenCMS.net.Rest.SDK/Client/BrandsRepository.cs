using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class BrandsRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Brand, GS.PflanzenCMS.Rest.SDK.Models.Brand.Summary>, IBrandsRepository
    {
        public BrandsRepository(Context context)
            :base(context,"api/brands")
        {
            
        }

    }
}