using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class DeliverTime : Entity
    {
        public long DeliverTimeID { get; set; }
        public int? FromDays { get; set; }
        public int? ToDays { get; set; }
        public int? Hours { get; set; }
    }
}