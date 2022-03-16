using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class User : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long UserID { get; set; }
            public string Name { get; set; }
            public string EMail { get; set; }
            public string Login { get; set; }
        }

        public long UserID { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSeed { get; set; }
        public string Description { get; set; }
        public PictureEntityReference Picture { get; set; }
        public bool Locked { get; set; }
        public bool Activated { get; set; }
        public bool AutomaticPassword { get; set; }
        public short? LockCount { get; set; }
        public Contact Contact { get; set; }
        public List<EntityReference> Roles { get; set; }
        public List<EntityReference> Rights { get; set; }
    }
}