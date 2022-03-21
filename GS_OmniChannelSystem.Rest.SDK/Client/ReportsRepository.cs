using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class ReportsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Report, GS.OmniChannelSystem.Rest.SDK.Models.Report.Summary>, IReportsRepository
    {
        public ReportsRepository(Context context)
            :base(context, "api/reports")
        {
            
        }
    }
}