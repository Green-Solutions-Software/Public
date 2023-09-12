namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class MessagePosition : Entity
    {
        public long MessagePositionID { get; set; }
        public string External_Data { get; set; }
        public EntityReference OrderItem { get; set; }
        public EntityReference Message { get; set; }
        public int? Quantity { get; set; }
        public string Notes { get; set; }
        public ReturnReason? ReturnReason { get; set; }
    }
}
