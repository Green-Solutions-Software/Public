using System;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class CustomField : Entity
    {
        public long CustomFieldID { get; set; }
        public EntityReference Field { get; set; }
        public string StringValue { get; set; }
        public int? IntValue { get; set; }
        public DateTime? DateValue { get; set; }
        public double? FloatValue { get; set; }
        public bool? BoolValue { get; set; }
    }
}
