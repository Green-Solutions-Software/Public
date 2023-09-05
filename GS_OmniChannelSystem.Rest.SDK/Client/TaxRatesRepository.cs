using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class TaxRatesRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.TaxRate, GS.OmniChannelSystem.Rest.SDK.Models.TaxRate.Summary>, ITaxRatesRepository
    {
        public TaxRatesRepository(Context context)
            :base(context, "api/taxrates")
        {
            
        }
    }
}