using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class PaymentMethod : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long PaymentMethodID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public PictureEntityReference Picture { get; set; }
            public PaymentServiceType PaymentServiceType { get; set; }

            public string GetDisplayName(long languageID)
            {
                return this.Name;
            }
        }

        public long PaymentMethodID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PictureEntityReference Picture { get; set; }
        public string Hint { get; set; }
        public bool NotActive { get; set; }
        public bool ComingSoon { get; set; }
        public string PaymentServiceProvider { get; set; }
        public long Index { get; set; }
        public PaymentServiceType PaymentServiceType { get; set; }
        public SolvencyType? Solvency { get; set; }
    }
}