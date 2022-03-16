using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class MembersRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Member, GS.PflanzenCMS.Rest.SDK.Models.Member.Summary>, IMembersRepository
    {
        public MembersRepository(Context context)
            :base(context, "api/members")
        {
            
        }

    }
}