using GS.OmniChannelSystem.Rest.SDK.Models;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class InvoicesRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Invoice, GS.OmniChannelSystem.Rest.SDK.Models.Invoice.Summary>
        , IInvoicesRepository        
    {
        public InvoicesRepository(Context context)
            :base(context,"api/invoices")
        {
            
        }

        public Paginated<Invoice.Summary> FindAll(string search, int pageIndex, int pageSize, string orderBy, Filters.Invoices filter = null, long[] ids = null)
        {
            return FindAll(search, pageIndex, pageSize, orderBy, filter != null ? filter.ToString() : null, ids != null ? GS.OmniChannelSystem.Rest.SDK.Classes.Strings.ListStringCombine(ids, m => m.ToString(), ",") : null);
        }
    }
}