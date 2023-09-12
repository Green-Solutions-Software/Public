namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class InvoiceState : Entity
    {
        public long InvoiceStateID { get; set; }
        public InvoiceStateType State { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public System.DateTime? DueDate { get; set; }
        public DataFileEntityReference Document { get; set; }
    }
}