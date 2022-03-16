using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class CacheRepository : BaseRepository, ICacheRepository
    {
        public CacheRepository(Context context)
            :base(context)
        {
            
        }

        public void Clear()
        {
            this.context.ClearCache();
        }
    }
}