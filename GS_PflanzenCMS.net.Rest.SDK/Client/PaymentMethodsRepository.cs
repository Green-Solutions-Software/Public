using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class PaymentMethodsRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.PaymentMethod, GS.PflanzenCMS.Rest.SDK.Models.PaymentMethod.Summary>, IPaymentMethodsRepository
    {
        public PaymentMethodsRepository(Context context)
            :base(context, "api/paymentmethods")
        {
            
        }
    }
}