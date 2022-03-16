using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class TeasersRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Teaser, GS.PflanzenCMS.Rest.SDK.Models.Teaser.Summary>, ITeasersRepository
    {
        public TeasersRepository(Context context)
            :base(context, "api/teasers")
        {
            
        }
    }
}