using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class JobsRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Job, GS.PflanzenCMS.Rest.SDK.Models.Job.Summary>, IJobsRepository
    {
        public JobsRepository(Context context)
            :base(context,"api/jobs")
        {
            
        }
    }
}