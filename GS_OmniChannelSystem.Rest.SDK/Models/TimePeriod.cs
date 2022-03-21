using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class TimePeriod : Entity
    {
        public TimePeriod()
        {

        }

        public TimePeriod(short fromCW, short toCW, int stockQuantity)
        {
            this.FromCW = fromCW;
            this.ToCW = toCW;
            this.StockQuantity = stockQuantity;
        }

        public long TimePeriodID { get; set; }
        public short? FromCW { get; set; }
        public short? ToCW { get; set; }
        public double? FromMonth { get; set; }
        public double? ToMonth { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int? StockQuantity { get; set; }
    }
}