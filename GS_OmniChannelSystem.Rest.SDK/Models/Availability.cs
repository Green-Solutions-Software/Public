﻿using System;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Availability 
    {
        public long ID { get; set; }
        public long ArticleID { get; set; }
        public long ArticleKeyID { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int StockQuantity { get; set; }

        public Availability()
        {

        }
    }
}
