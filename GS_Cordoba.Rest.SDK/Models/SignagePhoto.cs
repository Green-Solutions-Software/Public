﻿using GS.Cordoba.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class SignagePhoto : Photo
    {
        public string Url { get; set; }

        public int? SrcX { get; set; }
        public int? SrcY { get; set; }
        public int? SrcWidth { get; set; }
        public int? SrcHeight { get; set; }
        public int? Rotation { get; set; }
    }

}
