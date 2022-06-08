using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class PlantColor : Entity
    {
        public long PlantColorID { get; set; }
        public virtual EntityReference Color { get; set; }
        public PlantColorType Type { get; set; }
    }
}
