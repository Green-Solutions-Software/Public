using System;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class Entity
    {
        public Guid Guid { get; set; }

        public string RowVersion { get; set; }

        public bool Deleted { get; set; }
        
    }
}
