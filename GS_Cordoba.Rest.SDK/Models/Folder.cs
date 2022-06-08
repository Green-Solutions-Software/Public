using GS.Cordoba.Rest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Models
{
    public class Folder : MainEntity
    {
        public class Summary : Models.Summary
        {
            public long FolderID { get; set; }
            public PictureEntityReference Thumbnail { get; set; }
            public EntityReference Parent { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

            public string DescriptionOrDefault
            {
                get
                {
                    return !string.IsNullOrEmpty(this.Description) 
                        ? this.Description 
                        : "Ohne Beschreibung";
                }
            }
        }

        public long FolderID { get; set; }
        public string AutoThumbnailInfo { get; set; }
        public bool AutoThumbnail { get; set; }
        public PictureEntityReference Thumbnail { get; set; }
        public EntityReference Parent { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

    }
}
