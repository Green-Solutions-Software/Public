﻿using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IVideosRepository : IRepository<GS.OmniChannelSystem.Rest.SDK.Models.Video, GS.OmniChannelSystem.Rest.SDK.Models.Video.Summary>
    {
    }
}