using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IVouchersRepository : IRepository<GS.OmniChannelSystem.Rest.SDK.Models.Voucher, GS.OmniChannelSystem.Rest.SDK.Models.Voucher.Summary>
    {
        Models.FoundVoucher Find(string keyValue, string chainstore = null, bool external = false, bool exception = false);
        Models.Payment Reserve(long voucherID, long voucherCodeID, double amount, string currencyName, string info, int minutes, string chainstore = null);
        Models.Payment Cancel(long voucherID, long voucherCodeID, double amount, string currencyName, string info, string chainstore = null);
        Models.Voucher Pay(long paymentID);
    }
}
