using GS.Cordoba.Rest.SDK.Models;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Interfaces
{
    public interface ISearchRepository 
    {
        Task<PaginatedSearch> Search(string search, int pageIndex, int pageSize, string orderBy, SearchArgs args);
    }
}
