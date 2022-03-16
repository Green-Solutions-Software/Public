using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class CategoriesRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Category, GS.PflanzenCMS.Rest.SDK.Models.Category.Summary>, ICategoriesRepository
    {
        public CategoriesRepository(Context context)
            :base(context,"api/categories")
        {
            
        }
    }
}