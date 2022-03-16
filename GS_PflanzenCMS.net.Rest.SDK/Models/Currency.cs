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

    }
}
