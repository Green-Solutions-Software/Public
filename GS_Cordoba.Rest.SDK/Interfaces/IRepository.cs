using GS.Cordoba.Rest.SDK.Classes;
using GS.Cordoba.Rest.SDK.Models;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Interfaces
{
    public interface IRepository<T,S> 
        where T : Entity
        where S : Summary
    {
        Task<Paginated<S>> FindAll(string search, int pageIndex, int pageSize, string orderBy, long[] ids = null);

        Task<T> Get(long id);
    }
}
