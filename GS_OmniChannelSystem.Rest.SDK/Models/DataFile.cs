namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class DataFile : File
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long FileID { get; set; }
            public int Revision { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public long Size { get; set; }
        }

    }
}
