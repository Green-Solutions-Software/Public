using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class CustomerGroupsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.CustomerGroup, GS.OmniChannelSystem.Rest.SDK.Models.CustomerGroup.Summary>, ICustomerGroupsRepository
    {
        public CustomerGroupsRepository(Context context)
            :base(context, "api/customergroups")
        {
            
        }

        public GS.OmniChannelSystem.Rest.SDK.Models.CustomerGroup GetByKey(string key)
        {
            return context.GetByKey<GS.OmniChannelSystem.Rest.SDK.Models.CustomerGroup>(this.resource, key);
        }

    }
}