namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Address : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long AddressID { get; set; }
            public string Street { get; set; }
            public string HouseNumber { get; set; }
            public string Zip { get; set; }
            public string City { get; set; }
        }

        public long AddressID { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Postbox { get; set; }
        public string Info { get; set; }
        public EntityReference Country { get; set; }
        public AddressType Type { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

        public string GetDisplayName(long languageID)
        {
            var result = (this.Street + " " + this.HouseNumber).Trim();
            //if (!string.IsNullOrEmpty(this.HouseNumber))
            //    result = GS.OmniChannelSystem.Rest.SDK.Classes.Strings.strCombine(result, this.HouseNumber, ", ");
            if (!string.IsNullOrEmpty(this.Zip + " " + this.City))
                result = GS.OmniChannelSystem.Rest.SDK.Classes.Strings.strCombine(result, (this.Zip + " " + this.City).Trim(), ", ");

            //if (this.Country != null)
            //    result = GS.OmniChannelSystem.Rest.SDK.Classes.Strings.strCombine(result, this.Country.Name, ", ");

            if (!string.IsNullOrEmpty(this.Postbox))
                result += ", " + this.Postbox;
            if (!string.IsNullOrEmpty(this.Info))
                result += ", " + this.Info;
            return result;
        }
    }
}