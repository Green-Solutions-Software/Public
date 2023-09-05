using System.Collections.Generic;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class Signage : MainEntity
    {
        public class Summary : Models.Summary
        {
            public long SignageID { get; set; }
            public string Name { get; set; }
            public string Name2 { get; set; }
            public PictureEntityReference Thumbnail { get; set; }
        }

        public long SignageID { get; set; }
        public FontMultiplier? FontMultiplier { get; set; }
        public EntityReference TemplateFormat { get; set; }
        public EntityReference Language { get; set; }
        public EntityReference Template { get; set; }
        public EntityReference TemplateVersion { get; set; }
        public EntityReference Format { get; set; }
        public EntityReference Type { get; set; }
        public EntityReference Shortcut { get; set; }
        public int Revision { get; set; }
        public PictureEntityReference Thumbnail { get; set; }
        public EntityReference Default { get; set; }
        public double? Version { get; set; }
        public bool Incomplete { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Slogan { get; set; }
        public string Teaser { get; set; }
        public string Text { get; set; }
        public bool EANCode { get; set; }
        public string TextHTML { get; set; }
        public bool QRCode { get; set; }
        public string BarcodeEAN { get; set; }
        public string Barcode128 { get; set; }
        public bool Advertisement { get; set; }
        public string Free1 { get; set; }
        public string Free2 { get; set; }
        public string Free3 { get; set; }
        public string EditorBackgroundUrl { get; set; }
        public List<SignagePhoto> Photos { get; set; }
        public List<SignageArticle> Articles { get; set; }
        public string PotSize { get; set; }
        public List<EntityReference> Folders { get; set; }
        public List<EntityReference> Categories { get; set; }
        public List<EntityReference> Tags { get; set; }
        public List<SignagePrice> Prices { get; set; }
        public List<SignageProperty> Defaults { get; set; }
        public List<SignageVariable> Variables { get; set; }
        public string SearchText { get; set; }
    }
}
