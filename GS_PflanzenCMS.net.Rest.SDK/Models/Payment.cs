using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Payment : Entity
    {
        public long PaymentID { get; set; }

        public DateTime? ReservedUntil { get; set; }
        public string Info { get; set; }
        public double Price { get; set; }
        public EntityReference Currency { get; set; }
        public VoucherCode VoucherCode { get; set; }
        public EntityReference PaymentMethod { get; set; }
    }
}