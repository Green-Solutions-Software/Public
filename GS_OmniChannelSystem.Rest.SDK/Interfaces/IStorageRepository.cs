using GS.OmniChannelSystem.Rest.SDK.Models;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IStorageRepository
    {
        UrlResult Url(long id, int width = 800, int height = 800);
    }
}
