using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class PaymentMethodsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.PaymentMethod, GS.OmniChannelSystem.Rest.SDK.Models.PaymentMethod.Summary>, IPaymentMethodsRepository
    {
        public PaymentMethodsRepository(Context context)
            :base(context, "api/paymentmethods")
        {
            
        }
    }
}