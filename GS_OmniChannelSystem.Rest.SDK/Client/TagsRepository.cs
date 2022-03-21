using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class TagsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Tag, GS.OmniChannelSystem.Rest.SDK.Models.Tag.Summary>, ITagsRepository
    {
        public TagsRepository(Context context)
            :base(context, "api/tags")
        {
            
        }
    }
}