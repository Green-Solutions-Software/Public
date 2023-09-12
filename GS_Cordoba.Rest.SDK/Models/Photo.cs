namespace GS.Cordoba.Rest.SDK.Models
{
    public class Photo
    {
        public long PhotoID { get; set; }
        public PictureEntityReference Picture { get; set; }
        public EntityReference Language { get; set; }
        public string Title { get; set; }
        public PictureDisplayMode DisplayMode { get; set; }
        public int Priority { get; set; }
    }

}
