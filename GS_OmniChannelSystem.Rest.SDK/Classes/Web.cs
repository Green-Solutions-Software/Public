namespace GS.OmniChannelSystem.Rest.SDK.Classes
{
    public class Web
    {
        public static string Combine(string endpoint, string resource)
        {
            if (!endpoint.EndsWith("/"))
                endpoint += "/";
            return endpoint + resource;
        }
    }
}
