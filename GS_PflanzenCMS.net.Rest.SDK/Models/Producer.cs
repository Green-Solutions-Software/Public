﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Producer : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long ProducerID { get; set; }
            public string Name { get; set; }
        }

        public Producer()
        {
        }

        public long ProducerID { get; set; }
        public string Name { get; set; }
    }
}