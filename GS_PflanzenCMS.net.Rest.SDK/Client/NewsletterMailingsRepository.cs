using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class NewsletterMailingsRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.NewsletterMailing, GS.PflanzenCMS.Rest.SDK.Models.NewsletterMailing.Summary>, INewsletterMailingRepository
    {
        public NewsletterMailingsRepository(Context context)
            :base(context, "api/newslettermailings")
        {
            
        }
    }
}