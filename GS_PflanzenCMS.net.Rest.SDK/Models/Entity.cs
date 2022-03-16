using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Entity : Base
    {
        public Entity()
        {
        }

        public string External_Key { get; set; }
        public string External_RowVersion { get; set; }

        public long? External_COR_ID { get; set; }
        public long? External_DM_ID { get; set; }

        public string External_COR_Owner { get; set; }

        public string RowVersion { get; set; }

        public bool Deleted { get; set; }

        //public DateTime CreatedOn { get; set; }

    }

}
