using GS.OmniChannelSystem.Rest.SDK.Models;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class ContainersRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Container, GS.OmniChannelSystem.Rest.SDK.Models.Container.Summary>, IContainersRepository
    {
        public ContainersRepository(Context context)
            :base(context,"api/containers")
        {
            
        }

        public Container GetByKey(string key)
        {
            return this.context.GetContainerByKey(key);
        }
    }
}