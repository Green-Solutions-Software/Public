﻿namespace GS.Cordoba.Rest.SDK.Models
{
    public class PlantTask : Entity
    {
        public long PlantTaskID { get; set; }

        public virtual EntityReference Task { get; set; }

        public virtual TimePeriod Period { get; set; }

        public virtual TimePeriod Period2 { get; set; }

        public double? IntervalWeeks { get; set; }
    }
}
