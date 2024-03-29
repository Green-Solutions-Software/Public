﻿using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class SocialMediaPostsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.SocialMediaPost, GS.OmniChannelSystem.Rest.SDK.Models.SocialMediaPost.Summary>, ISocialMediaPostsRepository
    {
        public SocialMediaPostsRepository(Context context)
            :base(context, "api/socialmediaposts")
        {
            
        }
    }
}