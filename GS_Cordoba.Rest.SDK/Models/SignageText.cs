using GS.Cordoba.Rest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class SignageText : Entity
    {
        public long SignageTextID { get; set; }
        public TextType Type { get; set; }
        public bool Visible { get; set; }
        public short Position { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }

    }
}
