namespace GS.Cordoba.Rest.SDK.Interfaces
{
    public interface IFilesRepository 
    {
        string Url(long id, int width, int height, PictureDisplayMode displayMode = PictureDisplayMode.Cut, ScaleMode scaleMode = ScaleMode.ProportionalBiggest, int revision = 0);
    }
}
