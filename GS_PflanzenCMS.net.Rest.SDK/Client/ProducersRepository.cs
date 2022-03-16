using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class ProducersRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Producer, GS.PflanzenCMS.Rest.SDK.Models.Producer.Summary>, IProducersRepository
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