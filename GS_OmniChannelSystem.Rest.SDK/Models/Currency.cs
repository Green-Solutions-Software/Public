namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Currency : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long CurrencyID { get; set; }
            public string Name { get; set; }
            public string NameShort { get; set; }
            public double Factor { get; set; }
        }

        public long CurrencyID { get; set; }

        public string Name { get; set; }

        public double Factor { get; set; }

        public string NameShort { get; set; }

        public string Sign { get; set; }

    }
}
