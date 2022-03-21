using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class SetupConfigPage : Entity
    {
        public long SetupConfigPageID { get; set; }
        public string Key { get; set; }
        public EntityReference Page { get; set; }
    }
}