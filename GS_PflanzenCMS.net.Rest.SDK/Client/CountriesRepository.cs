using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class CountriesRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Country, GS.PflanzenCMS.Rest.SDK.Models.Country.Summary>, ICountriesRepository
    {
        public CountriesRepository(Context context)
            :base(context,"api/countries")
        {
            
        }

    }
}