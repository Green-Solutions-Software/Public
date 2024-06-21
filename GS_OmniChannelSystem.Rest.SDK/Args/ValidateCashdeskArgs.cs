using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Api.Args
{
    public class ValidatedVoucher
    {
        public class OrderItem
        {
            public Guid? Guid { get; set; }
            public double? Discount { get; set; }
            public double? DiscountPercent { get; set; }
            public OrderItem Giveaway { get; set; }
        }

        public EntityReferenceWithKey Voucher { get; set; }
        public double? Discount { get; set; }
        public double? DiscountPercent { get; set; }
        public VoucherType Type { get; set; }
        public List<OrderItem> Items { get; set; }
    }

    public class ValidateCashdeskArgs
    {
        public string BarcodeQR { get; set; }

        public CreateCashdeskArgs CashDesk { get; set; }

    }

    public class ValidateCashdeskResult 
    {       
        public bool PrintReceipt { get; set; }
        public EntityReferenceWithNumber Owner { get;set; }
        public EntityReferenceWithKey DebitCard { get; set; }
        public double? TotalDiscount { get; set; }
        public double? TotalDiscountPercent { get; set; }
        public double? Bonus { get; set; }
        public string Error { get; set; }
        public CreateCashdeskArgs CashDesk { get; set; }

        public List<ValidatedVoucher>Vouchers { get; set; }

    }
}