﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Models
{

    public class MainEntity : Entity
    {
        public EntityReference Owner { get; set; }
    }
}