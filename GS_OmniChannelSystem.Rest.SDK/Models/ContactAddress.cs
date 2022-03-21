using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class ContactAddress : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long ContactAddressID { get; set; }
            public AddressType Type { get; set; }
            public EntityReference Address { get; set; }
            public EntityReference Contact { get; set; }
        }

        public long ContactAddressID { get; set; }
        public AddressType Type { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public EntityReference Member { get; set; }
        public string GetDisplayName(long languageID)
        {
            return Contact.GetDisplayName(languageID) + ", " + Address.GetDisplayName(languageID);
        }

    }
}