using GS.Cordoba.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class Address : Entity
    {
        public long AddressID { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Postbox { get; set; }
        public EntityReference Country { get; set; }
        public AddressType Type { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

        public string StreetAndHouseNumber
        {
            get
            {
                return ((this.Street ?? "") + " " + (this.HouseNumber ?? "")).Trim();
            }
        }

        public string ZipAndCity
        {
            get
            {
                return (this.Zip + " " + this.City).Trim();
            }
        }

        public string DisplayName
        {
            get
            {
                var result = (this.Street + " " + this.HouseNumber).Trim();
                if (!string.IsNullOrEmpty(this.Zip + " " + this.City))
                {
                    if (!string.IsNullOrEmpty(result))
                        result += ", ";
                    result += (this.Zip + " " + this.City).Trim();
                }


                if (this.Country != null)
                {
                    if (!string.IsNullOrEmpty(result))
                        result += ", ";
                }


                if (!string.IsNullOrEmpty(this.Postbox))
                    result += ", " + this.Postbox;
                return result;
            }
        }

        public override string ToString()
        {
            List<string> result = new List<string>();

            if (!string.IsNullOrEmpty(this.StreetAndHouseNumber))
                result.Add(this.StreetAndHouseNumber);
            if (!string.IsNullOrEmpty(this.ZipAndCity))
                result.Add(this.ZipAndCity);

            return GS.Cordoba.Rest.SDK.Classes.Strings.ListStringCombine(result, m => m, ", ");
        }

    }
}
