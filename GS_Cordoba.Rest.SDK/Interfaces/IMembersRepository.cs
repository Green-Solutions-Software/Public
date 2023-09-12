using GS.Cordoba.Rest.SDK.Classes;
using GS.Cordoba.Rest.SDK.Models;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Interfaces
{
    public interface IMembersRepository : IRepository<Member, Member.Summary>
    {
        Task<Paginated<Member.Summary>> FindAllActivated(string search, int pageIndex, int pageSize, string orderBy, long[] ids = null);
    }
}
