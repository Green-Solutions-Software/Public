using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class OrderItem : Entity
    {
        public long OrderItemID { get; set; }
        public List<EntityReference> ArticleGroups { get; set; }
        public DateTime Date { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Info { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public OrderItemPhoto Photo { get; set; }
        public ArticleKeyEntityReference ArticleKey { get; set; }
        public EntityReference Article { get; set; }
        public string Notes { get; set; }
        public ItemType Type { get; set; }
        public double Price { get; set; }
        public int PackingUnit { get; set; }
        public bool Stock { get; set; }
        public bool DropShip { get; set; }
        public EntityReference Currency { get; set; }
        public int Quantity { get; set; }
        public bool TaxIncluded { get; set; } // Incl. MwSt
        public double? Weight { get; set; }
        public DateTime? Rated { get; set; }
        public EntityReference RatedBy { get; set; }
        public int? Position { get; set; }
        public double TotalPrice { get; set; }
        public double TotalCosts { get; set; }
        public TaxRateEntityReference TaxRate { get; set; }
        public string Glyph { get; set; }
        public TransactionType TransactionType { get; set; }
        public EntityReference Transaction { get; set; }
        public List<VoucherEntityReference> Vouchers { get; set; }
        public bool? IsConfirmed { get; set; }
        public DateTime? Confirmed { get; set; }
        public User ConfirmedBy { get; set; }
        public int? QuantityConfirmed { get; set; }
        public EntityReference Supplier { get; set; }
        public string CustomerEAN { get; set; }
        public string CustomerArticleNumber { get; set; }
        public double? CustomerPrice { get; set; } // 10 EUR

        public string QuantityInfo
        {
            get
            {
                if (this.QuantityConfirmed != null)
                    return string.Format("{1} statt {0}", this.Quantity, this.QuantityConfirmed);

                return this.Quantity.ToString();
            }
        }
    }
}
