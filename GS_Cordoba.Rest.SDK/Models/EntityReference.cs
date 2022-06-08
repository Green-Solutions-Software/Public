
using GS.Cordoba.Rest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class EntityReference
    {
        public long ID { get; set; }

        public string RowVersion { get; set; }

        public string External_Key { get; set; }
       
    }

    public class EntityReferenceWithType : EntityReference
    {
        public string Type { get; set; }
    }

    public class EntityReferenceWithKey : EntityReference
    {
        public string Key { get; set; }
    }

    public class PictureEntityReference : EntityReference
    {
        public PictureEntityReference()
        {

        }

        public PictureEntityReference(long id, string url)
        {
            this.ID = id;
            this.Url = url;
        }

        public PictureEntityReference(long id, string url, PictureDisplayMode displayMode, int revision = 0)
        {
            this.ID = id;
            this.Url = url;
        }

        public string Url { get; set; }

        public string SmallUrl
        {
            get => Size(343, 219, ScaleMode.ProportionalSmallest);
        }

        public string SmallUrlBiggest
        {
            get => Size(343, 219, ScaleMode.ProportionalBiggest);
        }

        public string MediumUrl
        {
            get => Size(600, 400, ScaleMode.ProportionalSmallest);
        }

        public string MediumUrlBiggest
        {
            get => Size(600, 400, ScaleMode.ProportionalBiggest);
        }

        public string LargeUrl
        {
            get => Size(1200, 800, ScaleMode.ProportionalSmallest);
        }

        public string LargeUrlBiggest
        {
            get => Size(1200, 800, ScaleMode.ProportionalBiggest);
        }

        public string ThumbUrl
        {
            get => Size(128, 128, ScaleMode.ProportionalSmallest);
        }

        public string ThumbUrl256x128
        {
            get => Size(256, 128, ScaleMode.ProportionalSmallest);
        }

        public string ThumbUrl256x128Biggest
        {
            get => Size(256, 128, ScaleMode.ProportionalBiggest);
        }

        public string SliderUrl
        {
            get => MediumUrl;
        }

        public string Size(int width, int height, ScaleMode scaleMode = ScaleMode.ProportionalSmallest)
        {
            return null;

        }
    }

}
