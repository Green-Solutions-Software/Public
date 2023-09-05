namespace GS.OmniChannelSystem.Rest.SDK.Api.Args
{
    public class SearchCrossArgs : SearchArgs
    {
        public long? ReportID { get; set; }
        public long? VideoID { get; set; }
        public long? ArticleID { get; set; }
    }
}
