using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class RolesRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Role, GS.PflanzenCMS.Rest.SDK.Models.Role.Summary>, IRolesRepository
    {
        public RolesRepository(Context context)
            :base(context, "api/roles")
        {
            
        }

        public GS.PflanzenCMS.Rest.SDK.Models.Role GetByKey(string key)
        {
            return context.GetByKey<GS.PflanzenCMS.Rest.SDK.Models.Role>(this.resource,key);
        }
    }
}