using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IPicturesRepository : IRepository<GS.OmniChannelSystem.Rest.SDK.Models.Picture, GS.OmniChannelSystem.Rest.SDK.Models.Picture.Summary>
    {
        Picture Upload(UploadArgs args);

        Picture Upload(string filename);
    }
}
