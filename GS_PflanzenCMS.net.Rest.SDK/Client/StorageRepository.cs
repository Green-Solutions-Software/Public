using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class StorageRepository : BaseRepository, IStorageRepository
    {
        public StorageRepository(Context context)
            :base(context)
        {
            
        }

        public UrlResult Url(long id, int width = 800, int height = 800)
        {
            return this.context.GetStorageUrl(id, width, height);
        }

    }
}