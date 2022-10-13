using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GS.OmniChannelSystem.Rest.SDK.Api.Args
{

    public class OrderTransactionPosition
    {
        public long OrderItemID { get; set; }
        public int Quantity { get; set; }
        public string External_Key { get; set; }
        public DateTime? AvailableOn { get; set; }
        public OrderTransactionStatusType Status { get; set; }
        public TransactionType TransactionType { get; set; }
    }

    public class OrderTransactionPositions
    {
        // Auftragspositionen
        public List<OrderTransactionPosition> Positions { get; set; }

        // Versand
        public string[] TrackAndTraceID { get; set; }
        public string TrackAndTraceURL { get; set; }

        // Rechnung
        public string InvoiceURI { get; set; }
        public string InvoiceFilename { get; set; }
        public string InvoiceMimeType { get; set; }
        public long? InvoiceID { get; set; }

    }

    public class OrderUpdates
    {
        public Order Order { get; set; }
        public List<OrderTransactionArgs> Updates { get; set; }
    }

    public class OrderTransactionArticle
    {
        public string External_Key { get; set; }
        public long? OrderItemID { get; set; }
        public bool? Confirmed { get; set; }
        public int? QuantityConfirmed { get; set; }
        public string Replacement_External_Key { get; set; }
    }

    public class OrderTransactionArgs
    {
        public long? OrderTransactionID { get; set; }
        public OrderStatusType? OrderStatus { get; set; }
        public OrderTransactionStatusType? Status { get; set; }
        public OrderTransactionActionType? Action { get; set; }
        public DateTime? StatusOn { get; set; }
        public string[] TrackAndTraceID { get; set; }
        public string TrackAndTraceURL { get; set; }
        public string ShippingMethod { get; set; }
        public OrderDocumentation[] Documentations { get; set; }
        public OrderTransactionArticle[] Articles { get; set; }
        public string InvoiceURI { get; set; }
        public string InvoiceFilename { get; set; }
        public string InvoiceMimeType { get; set; }
        public long? ShippingMethodID { get; set; }
        public string Message { get; set; }
        public bool PlaceSupplierOrders { get; set; }
        public bool FireAndForget { get; set; }
        public DateTime? EarliestShippingDate { get; set; }
        public bool NoMails { get; set; }

        public OrderTransactionArgs()
        {

        }
    }
}
