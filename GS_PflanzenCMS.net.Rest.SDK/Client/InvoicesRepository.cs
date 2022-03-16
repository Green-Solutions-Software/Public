using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;
using GS.PflanzenCMS.Rest.SDK.Filters;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class InvoicesRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Invoice, GS.PflanzenCMS.Rest.SDK.Models.Invoice.Summary>
        , IInvoicesRepository        
    {
        public InvoicesRepository(Context context)
            :base(context,"api/invoices")
        {
            
        }

        public Paginated<Invoice.Summary> FindAll(string search, int pageIndex, int pageSize, string orderBy, Filters.Invoices filter = null, long[] ids = null)
        {
            return FindAll(search, pageIndex, pageSize, orderBy, filter != null ? filter.ToString() : null, ids != null ? VD.Library.Strings.ListStringCombine(ids, m => m.ToString(), ",") : null);
        }
    }
}