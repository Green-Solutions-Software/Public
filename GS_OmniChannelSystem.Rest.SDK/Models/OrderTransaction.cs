using System;
using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class OrderTransaction : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long OrderTransactionID { get; set; }
            public string DeliveredTrackAndTraceID { get; set; }
            public string DeliveredTrackAndTraceURL { get; set; }
            public OrderTransactionStatusType Status { get; set; }
            public DateTime? StatusOn { get; set; }
            public TransactionType Type { get; set; }
        }

        
        public long OrderTransactionID { get; set; }
        public string DeliveredTrackAndTraceID { get; set; }
        public string DeliveredTrackAndTraceURL { get; set; }
        public OrderTransactionStatusType Status { get; set; }
        public DateTime? AvailableOn { get; set; }
        public DateTime? StatusOn { get; set; }
        public TransactionType Type { get; set; }
        public string External_CMS_Number { get; set; }
        public string External_Data { get; set; }
        public string Message { get; set; }
        public List<OrderDocumentation> Documentations { get; set; }
        public List<EntityReference> ShipmentOrders { get; set; }
        public EntityReference Supplier { get; set; }
        public ContactAddress ShippingAddress { get; set; }
        public virtual ContactAddress InvoiceAddress { get; set; }

    }
}
