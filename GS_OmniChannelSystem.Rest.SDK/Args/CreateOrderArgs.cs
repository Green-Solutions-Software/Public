using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GS.OmniChannelSystem.Rest.SDK.Api.Args
{
    public class CreateOrderArgs
    {
        public class Result : Base
        {
            public long OrderID { get; set; }
            public long OrderTransactionID { get; set; }
        }

        public class Address
        {
            public string Street { get; set; }
            public string HouseNumber { get; set; }
            public string Zip { get; set; }
            public string City { get; set; }
            public string Postbox { get; set; }
            public string Country { get; set; }
            public string Info { get; set; }
            public AddressType Type { get; set; }
            public double? Longitude { get; set; }
            public double? Latitude { get; set; }

        }

        public class ContactAddress
        {
            public AddressType Type { get; set; }
            public Address Address { get; set; }
            public Contact Contact { get; set; }

        }

        public class Contact
        {
            public Apellation Apellation { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Phone { get; set; }
            public string Mobile { get; set; }
            public string Fax { get; set; }
            public string Homepage { get; set; }
            public string EMail { get; set; }
            public string Company { get; set; }
            public string Company2 { get; set; }
            public string Language { get; set; }

        }

        public class OrderItem
        {
            public DateTime Date { get; set; }
            public DateTime DeliveryDate { get; set; }
            public string Info { get; set; }
            public string Info2 { get; set; }
            public string ArticleKey { get; set; }
            public long? ArticleKeyID { get; set; }
            public string Notes { get; set; }
            public ItemType Type { get; set; }
            public double Price { get; set; }
            public string Currency { get; set; }
            public int Quantity { get; set; }
            public int? Position { get; set; }
            public double TotalPrice { get; set; }
            public double TotalCosts { get; set; }
            public double? TaxRate { get; set; }
            public bool Label { get; set; }
        }

        public ContactAddress InvoiceAddress { get; set; }
        public ContactAddress ShippingAddress { get; set; }
        public double TotalCostsArticles { get; set; }
        public double? TotalTaxCosts1 { get; set; }
        public double? TaxRate1 { get; set; }
        public double? TotalTaxCosts2 { get; set; }
        public double? TaxRate2 { get; set; }
        public double TotalCosts { get; set; }
        public double? TaxRateDeliver { get; set; }
        public double TotalTaxCostsDeliver { get; set; }
        public double TotalCostsDeliver { get; set; }
        public double TotalDiscount { get; set; }
        public string Notes { get; set; }
        public string Host { get; set; }
        public long PaymentMethodID { get; set; }
        public long ShippingMethodID { get; set; }
        public int? MinimumAge { get; set; }
        public long? External_CMS_OrderID { get; set; }
        public string External_CMS_Number { get; set; }
        public long? External_CMS_OwnerMemberID { get; set; }
        public long? External_CMS_TransactionID { get; set; }
        public string External_COR_Owner { get; set; }
        public string Currency { get; set; }
        public DateTime? WantedShippingDate { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public string ConfirmationEMailAddress { get; set; }
        public OrderStatusType? OrderStatus { get; set; }
        public string BarcodeQR { get; set; }

    }
}