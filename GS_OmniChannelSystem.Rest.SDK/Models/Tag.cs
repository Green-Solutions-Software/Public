﻿using System.Collections.Generic;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class Tag : Entity
    {
        public class Summary : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        {
            public long ContainerID { get; set; }
            public virtual string Name { get; set; }
            public virtual string Key { get; set; }
        }

        public long TagID { get; set; }
        public string Name { get; set; }
        public EntityReference Parent { get; set; }
        public List<TagSynonym> Synonyms { get; set; }
        public string Key { get; set; }

    }
}
