using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class TaxRatesRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.TaxRate, GS.PflanzenCMS.Rest.SDK.Models.TaxRate.Summary>, ITaxRatesRepository
    {
        public TaxRatesRepository(Context context)
            :base(context, "api/taxrates")
        {
            
        }
    }
}