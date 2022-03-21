using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class VouchersRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Voucher, GS.OmniChannelSystem.Rest.SDK.Models.Voucher.Summary>, IVouchersRepository
    {
        public VouchersRepository(Context context)
            :base(context, "api/vouchers")
        {
            
        }
    }
}