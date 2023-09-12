namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Settings : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long SettingsID { get; set; }
        }

        public long SettingsID { get; set; }
    }
}
