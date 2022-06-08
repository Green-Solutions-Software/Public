using GS.Cordoba.Rest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class Member : MainEntity
    {
        public class Summary : Models.Summary
        {
            public long MemberID { get; set; }
            public string MainContact { get; set; }
            public string ContactPerson { get; set; }
            public string MainAddress { get; set; }
            public PictureEntityReference Logo { get; set; }

            public string DisplayName { get => (MainContact!=null ? MainContact.Split(',').First() ?? "" : "").Trim(); }
            public string StreetAndHouseNumber { get => (MainAddress!=null ? MainAddress.Split(',').First() ?? "" : "").Trim(); }
            public string ZipCodeAndCity { get => (MainAddress!=null ? MainAddress.Split(',').ElementAtOrDefault(1) ?? "" : "").Trim(); }
        }

        public long MemberID { get; set; }
        public Contact MainContact { get; set; }
        public Contact ContactPerson { get; set; }
        public PictureEntityReference Logo { get; set; }
        public EntityReference CustomerGroup { get; set; }
        public ObservableCollection<Address> Adresses { get; set; } // N:1
        public ObservableCollection<MemberPhoto> Photos { get; set; } // N:1
        public ObservableCollection<EntityReferenceWithKey> Features { get; set; } // N:1

        public string Description { get; set; }
        public bool Locked { get; set; }
        public bool Guest { get; set; }
        public bool Activated { get; set; }
        public MemberType Type { get; set; }
        public string Number { get; set; }
        public string Comment { get; set; }
        public string Ceo { get; set; }

        public Address MainAddress
        {
            get
            {
                return this.Adresses.FirstOrDefault(m=>m.Type==AddressType.Main);
            }
        }

    }
}
