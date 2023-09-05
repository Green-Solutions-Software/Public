using GS.OmniChannelSystem.Rest.SDK.Models;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IPagesRepository : IRepository<GS.OmniChannelSystem.Rest.SDK.Models.Page, GS.OmniChannelSystem.Rest.SDK.Models.Page.Summary>
    {
        Paginated<GS.OmniChannelSystem.Rest.SDK.Models.Page.Summary> FindAll(long? parentId, string search, int pageIndex, int pageSize, string orderBy);
    }
}
