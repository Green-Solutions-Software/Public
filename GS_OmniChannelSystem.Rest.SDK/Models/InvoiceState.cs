using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class InvoiceState : Entity
    {
        public long InvoiceStateID { get; set; }
        public InvoiceStateType State { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public System.DateTime? DueDate { get; set; }
        public DataFileEntityReference Document { get; set; }
    }
}