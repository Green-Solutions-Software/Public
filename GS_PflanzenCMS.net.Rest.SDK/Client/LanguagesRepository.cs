using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class LanguagesRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Language, GS.PflanzenCMS.Rest.SDK.Models.Language.Summary>, ILanguagesRepository
    {
        public LanguagesRepository(Context context)
            :base(context, "api/languages")
        {
            
        }
    }
}