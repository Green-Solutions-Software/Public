using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Field : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long FieldID { get; set; }
            public FieldDataType DataType { get; set; }
            public FieldContentType? ContentType { get; set; }
            public string Name { get; set; }
            public string Key { get; set; }
        }

        public long FieldID { get; set; }
        public FieldDataType DataType { get; set; }
        public FieldContentType? ContentType { get; set; }
        public string Name { get; set; }
        public PictureEntityReference Picture { get; set; }
        public string Key { get; set; }
        public string Group { get; set; }
        public bool Invisible { get; set; }
        public bool Nullable { get; set; }

        public bool? Indexable { get; set; }
        public bool? IndexMultilang { get; set; }
        public bool? IndexRange { get; set; }
        public bool? IndexFacetable { get; set; }
        public bool? IndexFilterable { get; set; }
        public bool? IndexSearchable { get; set; }
    }
}
