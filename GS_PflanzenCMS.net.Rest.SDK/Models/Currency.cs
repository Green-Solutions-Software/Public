using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Currency : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
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
        public VD.Library.Amount Amount(double price)
        {
            return new VD.Library.Amount(price, new VD.Library.Currency(this.Sign ?? this.NameShort, this.Factor));
        }

        public static VD.Library.Amount Amount(double price, Currency currency)
        {
            if (currency == null)
                return new VD.Library.Amount(price, new VD.Library.Currency("??", 1.0));

            return new VD.Library.Amount(price, new VD.Library.Currency(currency.Sign ?? currency.NameShort, currency.Factor));
        }


    }
}
