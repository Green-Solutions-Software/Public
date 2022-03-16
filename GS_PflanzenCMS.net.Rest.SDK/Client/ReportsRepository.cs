using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class ReportsRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Report, GS.PflanzenCMS.Rest.SDK.Models.Report.Summary>, IReportsRepository
    {
        public ReportsRepository(Context context)
            :base(context, "api/reports")
        {
            
        }
    }
}