namespace GS.Cordoba.Rest.SDK.Models
{
    public class Template : MainEntity
    {
        public class Summary : GS.Cordoba.Rest.SDK.Models.Summary
        {
            public long FormatID { get; set; }
            public string Name { get; set; }
        }

        public long TemplateID { get; set; }
        public ProcessorType Processor { get; set; }
        public string Name { get; set; }
        public EntityReference Type { get; set; }
        public string Description { get; set; }
        public string EditorBackgroundUrl { get; set; }
        public bool Active { get; set; }
        public int? ArticleCount { get; set; }
        public PictureEntityReference Thumbnail { get; set; }
    }
}
