using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class MailTemplatesRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.MailTemplate, GS.PflanzenCMS.Rest.SDK.Models.MailTemplate.Summary>, IMailTemplatesRepository
    {
        public MailTemplatesRepository(Context context)
            :base(context, "api/mailtemplates")
        {
            
        }
    }
}