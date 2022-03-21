using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class SearchFacettValue
    {
        public string DisplayValue { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public string Value { get; set; }
        public string Search { get; set; }
        public int Count { get; set; }
        public double? From { get; set; }
        public double? To { get; set; }
    }

}