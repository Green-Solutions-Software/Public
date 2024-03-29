﻿using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class CurrenciesRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Currency, GS.OmniChannelSystem.Rest.SDK.Models.Currency.Summary>, ICurrenciesRepository
    {
        public CurrenciesRepository(Context context)
            :base(context,"api/currencies")
        {
            
        }

        public Currency GetByKey(string key)
        {
            throw new NotImplementedException();
        }
    }
}