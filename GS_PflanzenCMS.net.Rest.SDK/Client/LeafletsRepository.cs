using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class LeafletsRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Leaflet, GS.PflanzenCMS.Rest.SDK.Models.Leaflet.Summary>, ILeafletsRepository
    {
        public LeafletsRepository(Context context)
            :base(context, "api/leaflets")
        {
            
        }
    }
}