using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class ProducersRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Producer, GS.OmniChannelSystem.Rest.SDK.Models.Producer.Summary>, IProducersRepository
    {
        public ProducersRepository(Context context)
            :base(context, "api/producers")
        {
            
        }

        public Producer GetByKey(string key)
        {
            return this.context.GetProducerByKey(key);
        }
    }
}