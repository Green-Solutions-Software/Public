using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class RightsRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Right, GS.PflanzenCMS.Rest.SDK.Models.Right.Summary>, IRightsRepository
    {
        public RightsRepository(Context context)
            :base(context, "api/rights")
        {
            
        }
    }
}