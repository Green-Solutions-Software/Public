﻿using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Interfaces
{
    public interface IInvoicesRepository : 
        IRepository<GS.PflanzenCMS.Rest.SDK.Models.Invoice, GS.PflanzenCMS.Rest.SDK.Models.Invoice.Summary>,
        IFilteredRepository<GS.PflanzenCMS.Rest.SDK.Models.Invoice, GS.PflanzenCMS.Rest.SDK.Models.Invoice.Summary, GS.PflanzenCMS.Rest.SDK.Filters.Invoices>
    {
    }
}
