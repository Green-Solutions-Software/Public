namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class UrlResult : Base
    {
        public UrlResult()
        {

        }

        public UrlResult(string url)
        {
            this.Url = url;
        }

        public string Url { get; set; }
    }
}