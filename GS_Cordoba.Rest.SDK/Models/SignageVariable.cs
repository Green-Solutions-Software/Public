namespace GS.Cordoba.Rest.SDK.Models
{
    public class SignageVariable : Entity
    {
        public long SignageVariableID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
        public virtual SignagePhoto ImageValue { get; set; }
        public virtual int? IntValue { get; set; }

    }
}
