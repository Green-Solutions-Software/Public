using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IInvoicesRepository : 
        IRepository<GS.OmniChannelSystem.Rest.SDK.Models.Invoice, GS.OmniChannelSystem.Rest.SDK.Models.Invoice.Summary>,
        IFilteredRepository<GS.OmniChannelSystem.Rest.SDK.Models.Invoice, GS.OmniChannelSystem.Rest.SDK.Models.Invoice.Summary, GS.OmniChannelSystem.Rest.SDK.Filters.Invoices>
    {
    }
}
