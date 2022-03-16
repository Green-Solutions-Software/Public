using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class VouchersRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Voucher, GS.PflanzenCMS.Rest.SDK.Models.Voucher.Summary>, IVouchersRepository
    {
        public VouchersRepository(Context context)
            :base(context, "api/vouchers")
        {
            
        }
    }
}