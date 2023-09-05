namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IRolesRepository : IRepository<GS.OmniChannelSystem.Rest.SDK.Models.Role, GS.OmniChannelSystem.Rest.SDK.Models.Role.Summary>
    {
        GS.OmniChannelSystem.Rest.SDK.Models.Role GetByKey(string key);
    }
}
