using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class GalleriesRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Gallery, GS.PflanzenCMS.Rest.SDK.Models.Gallery.Summary>, IGalleriesRepository
    {
        public GalleriesRepository(Context context)
            :base(context, "api/galleries")
        {
            
        }

        public Gallery GetByKey(string key)
        {
            return this.context.GetGalleryByKey(key);
        }
    }
}