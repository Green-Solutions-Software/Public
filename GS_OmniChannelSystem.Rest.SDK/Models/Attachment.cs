﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Attachment: Entity
    {
        public long AttachmentID { get; set; }
        public EntityReference DataFile { get; set; }
        public EntityReference Language { get; set; }
        public string Title { get; set; }
    }

}