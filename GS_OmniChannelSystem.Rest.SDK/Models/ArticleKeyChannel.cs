using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class ArticleKeyChannel : Entity
    {
        public long ArticleKeyChannelID { get; set; }
        public EntityReference Channel { get; set; }
        public string Info { get; set; }
        public string Number { get; set; } // z.B. ASIN bei Amazon
        public string SKU { get; set; } // z.B. SKU bei Amazon
        public string ShippingTemplate { get; set; } // z.B. Versandvorlage bei Amazon
        public string PaymentTemplate { get; set; } // z.B. Zahlungsbedingungen bei eBay
        public string ReturnTemplate { get; set; } // z.B. Rücknahmebedingungen bei eBay
        public List<ArticleKeyPhoto> Photos { get; set; }
        public List<ArticleKeyPrice> Prices { get; set; }
    }
}