namespace GS.Cordoba.Rest.SDK.Models
{
    public class Picture : MainEntity
    {
        public class Summary : GS.Cordoba.Rest.SDK.Models.Summary
        {
            public long FileID { get; set; }
            public string Name { get; set; }
            public string Number { get; set; }
            public string Title { get; set; }
        }

        public long FileID { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public string Number { get; set; }
        public long Size { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int DpiX { get; set; }
        public int DpiY { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string SearchKeywords { get; set; }
        public string Url200x200ProportionalBiggest { get; set; }

        public string Url600x600ProportionalBiggest { get; set; }

        public string Url1200x1200ProportionalBiggest { get; set; }

    }
}
