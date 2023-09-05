using System.Collections.Generic;

namespace GS.PflanzenCMS.Rest.SDK.Args
{
    public class ArticleTransactionPrice
    {
        public int? Quantity { get; set; } // ab x Stück
        public double Price { get; set; } // 10 EUR
        public double? PriceOld { get; set; }
    }

    public class ArticleTransactionArgs
    {
        public string External_Key { get; set; }
        public int? StockQuantity { get; set; }
        public bool? Inactive { get; set; }
        public List<ArticleTransactionPrice> Prices { get; set; }
    }
}
