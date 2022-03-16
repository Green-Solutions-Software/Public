using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class MenusRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Menu, GS.PflanzenCMS.Rest.SDK.Models.Menu.Summary>, IMenusRepository
    {
        public MenusRepository(Context context)
            :base(context, "api/menus")
        {
            
        }
    }
}