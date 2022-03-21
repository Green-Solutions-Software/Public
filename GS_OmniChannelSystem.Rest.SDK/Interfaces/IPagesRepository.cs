using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IPagesRepository : IRepository<GS.OmniChannelSystem.Rest.SDK.Models.Page, GS.OmniChannelSystem.Rest.SDK.Models.Page.Summary>
    {
        Paginated<GS.OmniChannelSystem.Rest.SDK.Models.Page.Summary> FindAll(long? parentId, string search, int pageIndex, int pageSize, string orderBy);
    }
}
