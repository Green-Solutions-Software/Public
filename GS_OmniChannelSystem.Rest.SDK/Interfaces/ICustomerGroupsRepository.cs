namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface ICustomerGroupsRepository : IRepository<GS.OmniChannelSystem.Rest.SDK.Models.CustomerGroup, GS.OmniChannelSystem.Rest.SDK.Models.CustomerGroup.Summary>
    {
        GS.OmniChannelSystem.Rest.SDK.Models.CustomerGroup GetByKey(string key);
    }
}
