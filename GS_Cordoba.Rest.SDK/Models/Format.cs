namespace GS.Cordoba.Rest.SDK.Models
{
    public class Format : MainEntity
    {
        public class Summary : GS.Cordoba.Rest.SDK.Models.Summary
        {
            public long FormatID { get; set; }
            public string Name { get; set; }
            public PictureEntityReference Thumbnail { get; set; }
        }

        public long FormatID { get; set; }
        public string Name { get; set; }
        public string XMLContent { get; set; }
        public double? WidthMM { get; set; }
        public double? HeightMM { get; set; }
        public int? Revision { get; set; }
        public double? Version { get; set; }
        public bool Active { get; set; }
        public string Filename { get; set; }
        public PictureEntityReference Thumbnail { get; set; }
    }
}
