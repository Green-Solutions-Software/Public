namespace GS.Cordoba.Rest.SDK.Models
{
    public class Currency : MainEntity
    {
        public class Summary : Models.Summary
        {
            public long CurrencyID { get; set; }
            public string Name { get; set; }
            public string NameShort { get; set; }

            public string GetDisplayName(long languageID)
            {
                return this.Name;
            }
        }

        public long CurrencyID { get; set; }
        public string Name { get; set; }
        public double Factor { get; set; }
        public string NameShort { get; set; }
        public string Sign { get; set; }
    }
}
