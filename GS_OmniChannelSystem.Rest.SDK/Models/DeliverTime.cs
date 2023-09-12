namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class DeliverTime : Entity
    {
        public long DeliverTimeID { get; set; }
        public int? FromDays { get; set; }
        public int? ToDays { get; set; }
        public int? Hours { get; set; }
    }
}