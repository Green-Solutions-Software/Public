using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class TimelinesRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Timeline, GS.PflanzenCMS.Rest.SDK.Models.Timeline.Summary>, ITimelinesRepository
    {
        public TimelinesRepository(Context context)
            :base(context, "api/timelines")
        {
            
        }
    }
}