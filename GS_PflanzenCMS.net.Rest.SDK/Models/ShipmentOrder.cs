using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class ShipmentOrder : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long ShipmentOrderID { get; set; }
            public string Name { get; set; }
            public virtual EntityReference ShippingMethod { get; set; }

            public string GetDisplayName(long languageID)
            {
                return this.Name;
            }

            public string GetNumber()
            {
                return this.CreatedOn.Date.Year + "-" + this.ShipmentOrderID.ToString();
            }
        }


        public long ShipmentOrderID { get; set; }
        public string Name { get; set; }
        public List<ShipmentOrderItem> Items { get; set; }

        public EntityReference PaymentMethod { get; set; }
        public EntityReference ShippingMethod { get; set; }
        public EntityReference Member { get; set; }

        public ContactAddress AddressFrom { get; set; }
        public ContactAddress AddressTo { get; set; }

        public EntityReference Order { get; set; }
        public EntityReference Transaction { get; set; }

        public DateTime Date { get; set; }

        public DateTime? TakenOn { get; set; }
        public DateTime? CancelledOn { get; set; }
        public DateTime CreatedOn { get; set; }

        public string Data { get; set; }

        public string GetNumber()
        {
            return this.CreatedOn.Date.Year + "-" + this.ShipmentOrderID.ToString();
        }

    }
}
