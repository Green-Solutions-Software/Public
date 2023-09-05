using System;
using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Order : MainEntity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long OrderID { get; set; }
            public string Notes { get; set; }
            public double TotalCostsArticles { get; set; }
            public double? TotalTaxCosts1 { get; set; }
            public EntityReference TaxRate1 { get; set; }
            public double? TotalTaxCosts2 { get; set; }
            public EntityReference TaxRate2 { get; set; }
            public double TotalCosts { get; set; }
            public OrderStatusType Status { get; set; }
            public string OwnerName { get; internal set; }
            public string GetNumber()
            {
                return this.CreatedOn.Date.Year + "-" + this.OrderID.ToString();
            }
        }

        public long OrderID { get; set; }
        public EntityReference Voucher { get; set; }
        public EntityReference VoucherCode { get; set; }
        public ContactAddress InvoiceAddress { get; set; }
        public ContactAddress ShippingAddress { get; set; }
        public OrderStatusType Status { get; set; }
        public OrderType Type { get; set; }
        public DateTime? StatusOn { get; set; }
        public DateTime? RecentOn { get; set; }
        public DateTime? CancelledOn { get; set; }
        public bool DontCalculate { get; set; }
        public string ReceiptNumber { get; set; }
        public double TotalCostsArticles { get; set; }
        public double TotalPaid { get; set; }
        public double? TotalTaxCosts1 { get; set; }
        public TaxRateEntityReference TaxRate1 { get; set; }
        public double? TotalTaxCosts2 { get; set; }
        public TaxRateEntityReference TaxRate2 { get; set; }
        public double? TotalTaxCosts3 { get; set; }
        public TaxRateEntityReference TaxRate3 { get; set; }
        public double? TotalTaxCosts4 { get; set; }
        public TaxRateEntityReference TaxRate4 { get; set; }
        public double TotalCosts { get; set; }
        public DateTime? WantedShippingDate { get; set; }
        public DateTime? LoadingDate { get; set; }

        public double TotalTaxCostsDeliver { get; set; }
        public double TotalCostsDeliver { get; set; }
        public TaxRateEntityReference TaxRateDeliver { get; set; }

        public double TotalCostsShipping { get; set; }
        public double TotalTaxCostsShipping { get; set; }
        public TaxRateEntityReference TaxRateShipping { get; set; }

        public double TotalDiscount { get; set; }
        public double? TotalWeight { get; set; }
        public double TotalTaxCostsDiscount { get; set; }
        public double Discount { get; set; }
        public TaxRateEntityReference TaxRateDiscount { get; set; }
        public EntityReference ApprovedBy { get; set; }
        public EntityReference Channel { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public string Notes { get; set; }
        public EntityReference Supplier { get; set; }
        public EntityReference File { get; set; }
        public EntityReference Currency { get; set; }
        public List<OrderItem> Items { get; set; }
        public List<OrderDocumentation> Documentations { get; set; }
        public List<OrderTransaction> Transactions { get; set; }
        public List<EntityReference> ShipmentOrders { get; set; }
        public List<Payment> Payments { get; set; }
        public EntityReference ShippingMethod { get; set; }
        public EntityReference PaymentMethod { get; set; }
        public EntityReference Basket { get; set; }
        public DateTime CreatedOn { get; set; }
        public EntityReference PickupChainStore { get; set; }
        public string External_CMS_Endpoint { get; set; }
        public string External_CMS_Number { get; set; }
        public string OwnerName { get; internal set; }
        public string ConfirmationMessage { get; set; }
        public string OwnerNumber { get; set; }

        public bool TaxPlus { get; set; }
        // Kasse
        public string Seller { get; set; }
        public string Cashier { get; set; }
        public string CashDescNumber { get; set; }


        public string GetNumber()
        {
            return this.CreatedOn.Date.Year + "-" + this.OrderID.ToString();
        }
    }
}
