namespace GS.Cordoba.Rest.SDK.Models
{
    public class Basket : MainEntity
    {
        public class Summary : Models.Summary
        {
            public long BasketID { get; set; }
            public BasketType Type { get; set; }
            public BasketState State { get; set; }
        }

        public long BasketID { get; set; }
        public BasketType Type { get; set; }
        public BasketState State { get; set; }
    }
}
