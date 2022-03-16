using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class OpeningTime : Entity
    {
        public long OpeningTimeID { get; set; }
        public string Name { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public DateTime OpenFrom { get; set; }
        public DateTime OpenTo { get; set; }
        public bool Closed { get; set; }
        public string OpeningTimesInfo { get; set; }
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

        public string GetDisplayName(long languageID)
        {
            return this.Name;
        }

        public bool Recurrent { get; set; }
        public bool WithName { get; set; }

    }
}
