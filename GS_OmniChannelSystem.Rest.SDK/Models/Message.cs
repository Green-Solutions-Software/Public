using System;
using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Message : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long MessageID { get; set; }
            public string Number { get; set; }
            public string Key { get; set; }
            public string External_Data2 { get; set; }
            public MessageType Type { get; set; }
            public DateTime? ProcessedOn { get; set; }
            public DateTime? DoneOn { get; set; }
            public EntityReference AcknowledgedBy { get; set; }
            public DateTime? AcknowledgedOn { get; set; }
            public bool? Succeeded { get; set; }
            public List<Result> Errors { get; set; }
        }

        public long MessageID { get; set; }
        public string Key { get; set; }
        public string Number { get; set; }
        public Guid Guid { get; set; }
        public MessageType Type { get; set; }
        public MessageDirection Direction { get; set; }
        public DateTime? ProcessedOn { get; set; }
        public DateTime? DoneOn { get; set; }
        public bool SenderConfirm { get; set; }
        public DateTime? SenderConfirmedOn { get; set; }
        public User HasReadBy { get; set; }
        public bool? Succeeded { get; set; }
        public DateTime? HasReadOn { get; set; }
        public EntityReference AcknowledgedBy { get; set; }
        public DateTime? AcknowledgedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public EntityReference DoneBy { get; set; }
        public EntityReference Editor { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Html { get; set; }
        public string External_Data { get; set; }
        public string External_Data2 { get; set; }
        public string External_CMS_Number { get; set; }
        public long? External_CMS_ID { get; set; }
        public long? External_CMS_CAPS { get; set; }
        public string ExternalID { get; set; }
        public bool Refund { get; set; }
        public bool Replacement { get; set; }
        public string SupplierNumber { get; set; }
        public string GLN { get; set; }
        public EntityReference Channel { get; set; }
        public EntityReference Order { get; set; }
        public EntityReferenceWithGuid Parent { get; set; }
        public EntityReference Sender { get; set; }
        public EntityReference SendedBy { get; set; }
        public EntityReference Receiver { get; set; }
        public List<EntityReference> Children { get; set; }
        public List<MessagePosition> Positions { get; set; }
        public List<Result> Results { get; set; }
    }
}
