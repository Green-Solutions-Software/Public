using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Api.Args
{
    public class CreateCashdeskArgs
    {
        public class Result : Base
        {
            public long OrderID { get; set; }
            public long OrderTransactionID { get; set; }
        }

        public class OrderItem
        {
            public DateTime Date { get; set; }
            public string Info { get; set; }
            public string ArticleKey { get; set; }
            public long? ArticleKeyID { get; set; }
            public string Notes { get; set; }
            public ItemType Type { get; set; }
            public string Currency { get; set; }
            public int Quantity { get; set; }
            public int? Position { get; set; }
            public double? TaxRate { get; set; }
            public double? FixedTaxRate { get; set; }
            public double? Price { get; set; }
            public double? TotalPrice { get; set; }
            public string External_Key { get; set; }

            public OrderItem()
            {

            }

        }

        public CreateCashdeskArgs()
        {

        }

        public double TotalCostsArticles { get; set; }
        public double? TotalTaxCosts1 { get; set; }
        public double? TaxRate1 { get; set; }
        public double? TotalTaxCosts2 { get; set; }
        public double? TaxRate2 { get; set; }
        public double TotalCosts { get; set; }
        public double TotalDiscount { get; set; }
        public string BarcodeQR { get; set; }
        public long PaymentMethodID { get; set; }
        public string External_CMS_Number { get; set; }
        public long? External_CMS_OrderID { get; set; }
        public long? External_CMS_TransactionID { get; set; }
        public string External_Key2 { get; set; }
        public long? External_CMS_CAPS { get; set; }
        public string External_COR_Owner { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public double? FixedTotalDiscount { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public OrderStatusType? OrderStatus { get; set; }
        public long? OwnerMemberID { get; set; }
        public DateTime? Date { get; set; }

    }
}