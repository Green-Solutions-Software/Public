using GS.Cordoba.Rest.SDK.Interfaces;

namespace GS.Cordoba.Rest.SDK.Repositories
{
    public class CORFilesRepository : Repository, IFilesRepository
    {
        public CORFilesRepository(Context context) : base(context)
        {
        }

        public string Url(long id, int width, int height, PictureDisplayMode displayMode = PictureDisplayMode.Cut, ScaleMode scaleMode = ScaleMode.ProportionalBiggest, int revision = 0)
        {
            return this.context.FilesUrl(id, width, height, displayMode, scaleMode, revision);
        }




    }
}
