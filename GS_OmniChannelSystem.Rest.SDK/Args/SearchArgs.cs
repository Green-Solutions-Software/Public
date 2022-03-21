using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Api.Args
{
    public class SearchArgs
    {
        public string[] Types { get; set; }
        public string[] Select { get; set; }
        public string[] NestedTypes { get; set; }
        public string[] Facetts { get; set; }
        public string KeyValue { get; set; }
        public string EAN { get; set; }
        public string LastChange { get; set; }
        public long? MemberID { get; set; }
        public long? ContainerID { get; set; }
        public long? TimelineID { get; set; }
        public long? External_COR_ID { get; set; }
        public long? CategoryID { get; set; }

        public bool DoYouMean { get; set; }
        public int? BloomingTimeFrom { get; set; }
        public int? BloomingTimeTo { get; set; }
        public double? WidthFrom { get; set; }
        public double? WidthTo { get; set; }
        public double? HeightTo { get; set; }
        public double? HeightFrom { get; set; }
        public double? WeightTo { get; set; }
        public double? WeightFrom { get; set; }
        public double? GrowthTo { get; set; }
        public double? GrowthFrom { get; set; }
        public string[] SearchFacetts { get; set; }

        public DateTime? ValidTo { get; set; }

        public long[] FeatureIds { get; set; }

        public bool? AvailableForDropShipping { get; set; }

        public ReportType? ReportType { get; set; }
        public bool WithPhoto { get; set; }
        public bool? Inactive { get; set; }
        public string CultreInfo { get; set; }
    }
}
