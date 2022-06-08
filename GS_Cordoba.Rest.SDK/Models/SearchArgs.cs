using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class SearchArgs
    {
        public SearchArgs()
        {
            this.Types = new string[] { "Article" };
        }

        //public SearchArgs(SearchFilter filter)
        //{
        //    this.Types = new string[] { "Article" };
        //    this.DoYouMean = true;

        //    var searchFacetts = new List<string>();
        //    foreach (var facett in filter.Facetts.Where(m => m.Search != null))
        //        searchFacetts.Add(facett.Search);
        //    this.SearchFacetts = searchFacetts.ToArray();
        //}

        public bool DoYouMean { get; set; }

        public string[] Types { get; set; }
        public string[] Facetts { get; set; }
        public string KeyValue { get; set; }
        public string EAN { get; set; }
        public string LastChange { get; set; }

        public long? MemberID { get; set; }
        public long? ContainerID { get; set; }
        public long? External_COR_ID { get; set; }

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

        public long[] FeatureIds { get; set; }
    }
}
