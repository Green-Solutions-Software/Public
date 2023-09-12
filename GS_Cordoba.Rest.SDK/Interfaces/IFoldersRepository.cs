using GS.Cordoba.Rest.SDK.Classes;
using GS.Cordoba.Rest.SDK.Models;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Interfaces
{
    public interface IFoldersRepository : IRepository<Folder, Folder.Summary>
    {
        Task<Paginated<Folder.Summary>> FindAll(long parentFolderID, string search, int pageIndex, int pageSize, string orderBy, long[] ids = null);
    }
}
