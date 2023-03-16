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

        public FoundVoucher Find(string keyValue, string chainstore = null, bool external = false, bool exception = false)
        {
            return this.context.FindVoucher(keyValue, chainstore, exception);
        }

        public Payment Reserve(long voucherID, long voucherCodeID, double amount, string currencyName, string info, int minutes, string chainstore = null)
        {
            return this.context.ReserveVoucher(voucherID, voucherCodeID, amount, currencyName, info, minutes, chainstore);
        }

        public Payment Cancel(long voucherID, long voucherCodeID, double amount, string currencyName, string info, string chainstore = null)
        {
            return this.context.CancelVoucher(voucherID, voucherCodeID, amount, currencyName, info, chainstore);
        }

        public Models.Voucher Pay(long paymentID)
        {
            return this.context.PayVoucher(paymentID);
        }
    }
}