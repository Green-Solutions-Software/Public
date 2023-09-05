namespace GS.Cordoba.Rest.SDK.Models
{
    public class SignagePicto : Entity
    {
        public long SignagePictoID { get; set; }
        public Picto Picto { get; set; }
        public PictoGroup Group { get; set; }
        public bool Visible { get; set; }
        public short Position { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }


    }
}
