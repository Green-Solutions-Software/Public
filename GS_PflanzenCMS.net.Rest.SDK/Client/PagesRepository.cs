using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class PagesRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Page, GS.PflanzenCMS.Rest.SDK.Models.Page.Summary>, IPagesRepository
    {
        public PagesRepository(Context context)
            :base(context, "api/pages")
        {
            
        }

        public Paginated<GS.PflanzenCMS.Rest.SDK.Models.Page.Summary> FindAll(long? parentId, string search, int pageIndex, int pageSize, string orderBy)
        {
            return this.context.FindPages(parentId, search, pageIndex, pageSize, orderBy);
        }

    }
}