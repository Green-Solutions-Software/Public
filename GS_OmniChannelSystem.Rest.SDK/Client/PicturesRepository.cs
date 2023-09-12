using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;
using GS.OmniChannelSystem.Rest.SDK.Classes;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class PicturesRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Picture, GS.OmniChannelSystem.Rest.SDK.Models.Picture.Summary>, IPicturesRepository
    {
        public PicturesRepository(Context context)
            :base(context, "api/pictures")
        {
            
        }

        public Picture Upload(UploadArgs args)
        {
            return this.context.UploadPicture(args);
        }

        public Picture Upload(string filename)
        {
            return Upload(
                new UploadArgs()
                {
                    Data = new DataUri(System.IO.File.ReadAllBytes(filename)).ToString(),
                    Filename = System.IO.Path.GetFileName(filename),
                }
            );
        }
    }
}