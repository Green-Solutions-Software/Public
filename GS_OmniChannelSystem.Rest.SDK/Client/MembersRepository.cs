using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class MembersRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Member, GS.OmniChannelSystem.Rest.SDK.Models.Member.Summary>, IMembersRepository
    {
        public MembersRepository(Context context)
            :base(context, "api/members")
        {
            
        }

    }
}