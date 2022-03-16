using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class FieldsRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Field, GS.PflanzenCMS.Rest.SDK.Models.Field.Summary>, IFieldsRepository
    {
        public FieldsRepository(Context context)
            :base(context, "api/fields")
        {
            
        }
    }
}