namespace GS.Cordoba.Rest.SDK.Models
{
    public class SignagePrice : Entity
    {
        public long SignagePriceID { get; set; }
        public int Index { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string PriceUnit { get; set; }
        public string PriceBase { get; set; }
        public string PriceOld { get; set; }


    }
}
