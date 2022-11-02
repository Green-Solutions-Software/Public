using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Member : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long MemberID { get; set; }
            public string MainContact { get; set; }
            public string ContactPerson { get; set; }
            public string MainAddress { get; set; }
            public PictureEntityReference Logo { get; set; }
        }

        public long MemberID { get; set; }
        public string External_Data { get; set; }
        public Contact MainContact { get; set; }
        public EntityReference ContactPerson { get; set; }
        public PictureEntityReference Logo { get; set; }
        public EntityReference CustomerGroup { get; set; }
        public EntityReference Currency { get; set; }
        public EntityReference Channel { get; set; }
        public List<Address> Adresses { get; set; } // N:1
        public List<MemberPhoto> Photos { get; set; } // N:1
        public List<ContactAddress> ContactAddresses { get; set; } // N:1
        public List<User> Users { get; set; } // N:1
        public List<EntityReferenceWithKey> Features { get; set; } // N:1
        public List<EntityReference> Articles { get; set; }
        public List<EntityReference> Roles { get; set; }
        public List<EntityReference> Rights { get; set; }
        public List<EntityReference> Pricelists { get; set; }
        public List<CalculationGroupItem> Conditions { get; set; }
        public List<Contact> Contacts { get; set; } // N:1
        public string Description { get; set; }
        public bool Locked { get; set; }
        public bool Guest { get; set; }
        public bool Activated { get; set; }
        public MemberType Type { get; set; }
        public string Number { get; set; }
        public string Comment { get; set; }
        public string Ceo { get; set; }
    }
}
