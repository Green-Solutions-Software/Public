using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class CountriesRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Country, GS.OmniChannelSystem.Rest.SDK.Models.Country.Summary>, ICountriesRepository
    {
        public CountriesRepository(Context context)
            :base(context,"api/countries")
        {
            
        }

    }
}