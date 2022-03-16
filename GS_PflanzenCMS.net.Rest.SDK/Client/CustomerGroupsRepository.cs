using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class CustomerGroupsRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.CustomerGroup, GS.PflanzenCMS.Rest.SDK.Models.CustomerGroup.Summary>, ICustomerGroupsRepository
    {
        public CustomerGroupsRepository(Context context)
            :base(context, "api/customergroups")
        {
            
        }

        public GS.PflanzenCMS.Rest.SDK.Models.CustomerGroup GetByKey(string key)
        {
            return context.GetByKey<GS.PflanzenCMS.Rest.SDK.Models.CustomerGroup>(this.resource, key);
        }

    }
}