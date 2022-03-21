using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IArticlePropertiesRepository : IRepository<GS.OmniChannelSystem.Rest.SDK.Models.ArticleProperty, GS.OmniChannelSystem.Rest.SDK.Models.ArticleProperty.Summary>
    {
    }
}
