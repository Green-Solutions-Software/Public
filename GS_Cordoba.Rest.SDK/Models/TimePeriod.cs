using System;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class TimePeriod : Entity
    {
        public long TimePeriodID { get; set; }
        public short? FromCW { get; set; }
        public short? ToCW { get; set; }
        public double? FromMonth { get; set; }
        public double? ToMonth { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
