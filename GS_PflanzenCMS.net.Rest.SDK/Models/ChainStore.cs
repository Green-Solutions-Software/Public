using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class ChainStore : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long ChainStoreID { get; set; }
            public string Name { get; set; }
            public string Name2 { get; set; }
            public int Priority { get; set; }
            public Address Address { get; set; }
        }

        public long ChainStoreID { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
        public string SubDescription { get; set; }
        public Address Address { get; set; }

        public Contact Contact { get; set; }

        public EntityReference Page { get; set; }

        public List<ChainStorePhoto> Photos { get; set; }
        public List<EntityReference> Tags { get; set; }
        public List<OpeningTime> OpeningTimes { get; set; }

        public string Phone { get; set; }

        public string EMailAddress { get; set; }

        public string WebSite { get; set; }

        public string Fax { get; set; }

        public string AdditionalOpeningTimes { get; set; }

        public bool CanClickAndCollect { get; set; }

        public ChainStoreType Type { get; set; }

        //Social Media
        public string FacebookURL { get; set; }

        public string TwitterURL { get; set; }

        public string InstagramURL { get; set; }

        public string GooglePlusURL { get; set; }

        public string PinterestURL { get; set; }

        public string YoutubeURL { get; set; }

        //Weekdays
        public DateTime? OpenWeekdaysFrom { get; set; }
        public DateTime? OpenWeekdaysTo { get; set; }
        //Mondays
        public DateTime? OpenMondaysFrom { get; set; }
        public DateTime? OpenMondaysTo { get; set; }
        //Tuesdays
        public DateTime? OpenTuesdaysFrom { get; set; }
        public DateTime? OpenTuesdaysTo { get; set; }
        //Wednesdays
        public DateTime? OpenWednesdaysFrom { get; set; }
        public DateTime? OpenWednesdaysTo { get; set; }
        //Thursdays
        public DateTime? OpenThursdaysFrom { get; set; }
        public DateTime? OpenThursdaysTo { get; set; }
        //Fridays
        public DateTime? OpenFridaysFrom { get; set; }
        public DateTime? OpenFridaysTo { get; set; }
        //Saturdays
        public DateTime? OpenSaturdaysFrom { get; set; }
        public DateTime? OpenSaturdaysTo { get; set; }
        //Sundays
        public DateTime? OpenSundaysFrom { get; set; }
        public DateTime? OpenSundaysTo { get; set; }

        string OpeningTimesInfo { get; set; }
    }
}
