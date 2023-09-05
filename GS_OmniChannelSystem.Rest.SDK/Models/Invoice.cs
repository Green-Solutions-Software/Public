using System;
using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Invoice : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long InvoiceID { get; set; }
            public string Number { get; internal set; }
            public bool TaxPlus { get; set; }
            public System.DateTime Date { get; set; }
            public InvoiceType Type { get; set; }
            public EntityReference Member { get; set; }
            public double TotalPriceNet { get; set; }
            public double TotalPriceGros { get; set; }
            public double TotalPaid { get; set; }
        }

        public long InvoiceID { get; set; }
        public string Number { get; internal set; }
        public bool TaxPlus { get; set; }
        public System.DateTime Date { get; set; }
        public InvoiceType Type { get; set; }
        public bool AutomaticallyCreated { get; set; }
        public string Text { get; set; }
        public string Notes { get; set; }
        public string CancelationNote { get; set; }
        public string Description { get; set; }
        public System.DateTime? DeliveryDate { get; set; }
        public EntityReference Language { get; set; }
        public EntityReference Currency { get; set; }
        public EntityReference State { get; set; }
        public EntityReference Member { get; set; }
        public EntityReference DebitCard { get; set; }
        public EntityReference Address { get; set; }
        public EntityReference Sequence { get; set; }
        public SequenceItem SequenceItem { get; set; }
        public List<InvoicePosition> Positions { get; set; }
        public List<InvoiceState> States { get; set; }
        public List<Payment> Payments { get; set; }
        public List<EntityReference> Orders { get; set; }
        public DateTime? PaydOn { get; set; }
        public DateTime? DubiosOn { get; set; }
        public EntityReference PaymentMethod { get; set; }
        public List<EntityReference> Invoices { get; set; }
        public double TotalPriceNet { get; set; }
        public double TotalPriceGros { get; set; }
        public double TotalPaid { get; set; }        
        public string External_Data { get; set; }
        public long? External_CMS_ID { get; set; }
    }
}
