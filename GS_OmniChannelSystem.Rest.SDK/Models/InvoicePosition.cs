namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class InvoicePosition : Entity
    {
        public long InvoicePositionID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public EntityReference Currency { get; set; }
        public double TotalPrice { get; set; }
        public double TaxCosts { get; set; }
        public TaxRateEntityReference TaxRate { get; set; }
        public bool TaxIncluded { get; set; }
        public string Text { get; set; }
        public string Text2 { get; set; }
        public System.DateTime? BeginDate { get; set; }
        public System.DateTime? EndDate { get; set; }
        public EntityReference OrderItem { get; set; }
        public EntityReference BookAccount { get; set; }
        public EntityReference State { get; set; }
        public EntityReference ArticleKey { get; set; }
        public EntityReference Article { get; set; }
    }
}