using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class JobsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Job, GS.OmniChannelSystem.Rest.SDK.Models.Job.Summary>, IJobsRepository
    {
        public JobsRepository(Context context)
            :base(context,"api/jobs")
        {
            
        }
    }
}