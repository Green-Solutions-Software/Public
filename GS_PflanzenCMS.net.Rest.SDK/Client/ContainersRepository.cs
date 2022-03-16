using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class ContainersRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Container, GS.PflanzenCMS.Rest.SDK.Models.Container.Summary>, IContainersRepository
    {
        public ContainersRepository(Context context)
            :base(context,"api/containers")
        {
            
        }

        public Container GetByKey(string key)
        {
            return this.context.GetContainerByKey(key);
        }
    }
}