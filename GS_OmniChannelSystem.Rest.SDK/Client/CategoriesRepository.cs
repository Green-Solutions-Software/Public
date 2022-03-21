using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class CategoriesRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Category, GS.OmniChannelSystem.Rest.SDK.Models.Category.Summary>, ICategoriesRepository
    {
        public CategoriesRepository(Context context)
            :base(context,"api/categories")
        {
            
        }
    }
}