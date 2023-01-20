using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class PlantPicture : MainEntity
    {
        public class Summary : Models.Summary
        {
            public long FileID { get; set; }
            public string Number { get; set; }
            public string BotanicName { get; set; }
            public string NameTranslation { get; set; }
            public string TitleEx { get; set; }
        }

        public long FileID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ContentType { get; set; }
        public string Number { get; set; }
        public string ExtNumbers { get; set; }
        public string BotanicName { get; set; }
        public string NameTranslation { get; set; }
        public string TitleEx { get; set; }
        public double? HeightFrom { get; set; }
        public double? HeightTo { get; set; }
        public EntityReference PotSize { get; set; }
        public long Size { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int DpiX { get; set; }
        public int DpiY { get; set; }
        public ICollection<EntityReference> Colors { get; set; }
        public ICollection<EntityReference> Plants { get; set; }
        public PlantShapeType? ShapeType { get; set; }
        public ICollection<EntityReference> Tags { get; set; }
        public PlantPictureType Type { get; set; }

        public string Url200x200ProportionalBiggest { get; set; }
        public string Url600x600ProportionalBiggest { get; set; }
        public string Url1200x1200ProportionalBiggest { get; set; }
    }
}
