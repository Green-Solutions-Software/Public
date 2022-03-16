using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class VideosRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Video, GS.PflanzenCMS.Rest.SDK.Models.Video.Summary>, IVideosRepository
    {
        public VideosRepository(Context context)
            :base(context, "api/videos")
        {
            
        }
    }
}