using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class SocialMediaPostsRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.SocialMediaPost, GS.PflanzenCMS.Rest.SDK.Models.SocialMediaPost.Summary>, ISocialMediaPostsRepository
    {
        public SocialMediaPostsRepository(Context context)
            :base(context, "api/socialmediaposts")
        {
            
        }
    }
}