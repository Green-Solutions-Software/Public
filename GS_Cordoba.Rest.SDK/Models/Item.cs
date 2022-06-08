﻿using GS.Cordoba.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GS.Cordoba.Rest.SDK.Models
{
    public class Item : Entity
    {
        public long ID { get; set; }

        public string Title { get; set; }
        public string Title2 { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string NameTranslation { get; set; }
        public string Type { get; set; }

        public PictureDisplayMode PictureDisplayMode { get; set; }
        public long? PictureID { get; set; }

        public bool? AvailableForShipping { get; set; }
        public bool? AvailableForRadiusDelivery { get; set; }
        public bool? AvailableForClickAndCollect { get; set; }

        public double? MinKeyPrice { get; set; }
        public double? MaxKeyPrice { get; set; }
        public int? CountKeyPrices { get; set; }

        public double? MinKeyOldPrice { get; set; }
        public double? MaxKeyOldPrice { get; set; }
        public int? CountKeyOldPrices { get; set; }

        public long? CurrencyID { get; set; }

        public string TeaserColor { get; set; }
        public string TeaserTitle { get; set; }

        public int? Rating { get; set; }
        public int? RatingCount { get; set; }

        public ReportType? ReportType { get; set; }

        public string Url { get; set; }
        public string PictureUrl { get; set; }
        public string SmallPictureUrl { get; set; }
        public string MediumPictureUrl { get; set; }
        public string LargePictureUrl { get; set; }

        public string ThumbUrl
        {
            get
            {
                return this.PictureID != null
                    ? new PictureEntityReference(this.PictureID.Value, this.PictureUrl).ThumbUrl
                    : null;
            }
        }
    }
}