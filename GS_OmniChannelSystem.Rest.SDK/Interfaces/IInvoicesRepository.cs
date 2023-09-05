namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IInvoicesRepository : 
        IRepository<GS.OmniChannelSystem.Rest.SDK.Models.Invoice, GS.OmniChannelSystem.Rest.SDK.Models.Invoice.Summary>,
        IFilteredRepository<GS.OmniChannelSystem.Rest.SDK.Models.Invoice, GS.OmniChannelSystem.Rest.SDK.Models.Invoice.Summary, GS.OmniChannelSystem.Rest.SDK.Filters.Invoices>
    {
    }
}
