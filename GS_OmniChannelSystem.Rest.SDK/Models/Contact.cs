using System.Text;
using GS.OmniChannelSystem.Rest.SDK.Classes;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Contact : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long ContactID { get; set; }
            public EntityReference Picture { get; set; }
            public Apellation Apellation { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public long ContactID { get; set; }
        public EntityReference Picture { get; set; }
        public Apellation Apellation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Position { get; set; }
        public string Homepage { get; set; }
        public string EMail { get; set; }
        public string Company { get; set; }
        public string DisplayText { get; set; }
        public EntityReference Language { get; set; }

        public string GetDisplayName(long languageID)
        {
            if (!string.IsNullOrEmpty(this.DisplayText))
                return this.DisplayText;

            if (this.Apellation == Apellation.Company)
            {
                if (!string.IsNullOrEmpty(this.Company))
                    return Enums.Description(Apellation.Company) + " " + this.Company;
                else
                    return (this.FirstName + " " + this.LastName).Trim();
            }

            if (this.Apellation == Apellation.None)
                return (!string.IsNullOrEmpty(this.Company) ? this.Company : (this.FirstName + " " + this.LastName).Trim());

            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(this.Company))
                sb.Append(Enums.Description(Apellation.Company) + " " + this.Company + ", ");

            sb.Append((Enums.Description(this.Apellation) + " " + this.FirstName + " " + this.LastName).Trim());

            return sb.ToString();
        }
    }
}