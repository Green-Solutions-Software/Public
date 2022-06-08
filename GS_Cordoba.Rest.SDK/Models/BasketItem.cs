using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class BasketItem : Entity
    {
        public long BasketItemID { get; set; }
        public ItemType Type { get; set; }
        public string Number { get; set; }
        public string EAN { get; set; }
        public EntityReference Signage { get; set; }
        public EntityReference Format { get; set; }
        public BasketItemPhoto Photo { get; set; }
        public string Info { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public int Quantity { get; set; }

        public string QuantityInfo
        {
            get
            {
                return $"{this.Quantity} Stück";
            }
        }
    }
}
