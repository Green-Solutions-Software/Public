using System.Collections.Generic;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class SignageArticle : Entity
    {
        public long SignageArticleID { get; set; }
        public int Index { get; set; }
        public EntityReference Article { get; set; }
        public EntityReference Key { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public EntityReference Brand { get; set; }
        public string DescriptionHtml { get; set; }
        public string Description { get; set; }
        public string Free1 { get; set; }
        public string Free2 { get; set; }
        public string Free3 { get; set; }
        public string ShortDescription { get; set; }
        public string BarcodeUrl { get; set; }
        public string BarcodeEAN { get; set; }
        public string ArticleNumber { get; set; }
        public List<SignagePhoto> Photos { get; set; }
        public List<SignagePicto> Pictos { get; set; }
        public List<SignageText> Texts { get; set; }
        public List<SignagePrice> Prices { get; set; }
        public List<SignageVariable> Variables { get; set; }


    }
}
