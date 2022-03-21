using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class VideosRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Video, GS.OmniChannelSystem.Rest.SDK.Models.Video.Summary>, IVideosRepository
    {
        public VideosRepository(Context context)
            :base(context, "api/videos")
        {
            
        }
    }
}