using GS.Cordoba.Rest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class Contact: Entity
    {
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
        public string Company2 { get; set; }
        public EntityReference Language { get; set; }

        public string DisplayCompany
        {
            get => "Firma " + this.Company;
        }

        public string DisplayContact
        {
            get => this.FirstName + " " + this.LastName;
        }
    }
}
