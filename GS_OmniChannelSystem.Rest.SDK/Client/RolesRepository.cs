using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class RolesRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Role, GS.OmniChannelSystem.Rest.SDK.Models.Role.Summary>, IRolesRepository
    {
        public RolesRepository(Context context)
            :base(context, "api/roles")
        {
            
        }

        public GS.OmniChannelSystem.Rest.SDK.Models.Role GetByKey(string key)
        {
            return context.GetByKey<GS.OmniChannelSystem.Rest.SDK.Models.Role>(this.resource,key);
        }
    }
}