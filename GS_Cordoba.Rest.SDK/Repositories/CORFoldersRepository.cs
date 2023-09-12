using GS.Cordoba.Rest.SDK.Classes;
using GS.Cordoba.Rest.SDK.Interfaces;
using GS.Cordoba.Rest.SDK.Models;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Repositories
{
    public class CORFoldersRepository : Repository<Folder>, IFoldersRepository
    {
        public CORFoldersRepository(Context context) : base(context)
        {
        }

        public Task<Paginated<Folder.Summary>> FindAll(string search, int pageIndex, int pageSize, string orderBy, long[] ids = null)
        {
            return this.context.FindFolders(search, pageIndex, pageSize, orderBy);
        }

        public Task<Paginated<Folder.Summary>> FindAll(long parentFolderID, string search, int pageIndex, int pageSize, string orderBy, long[] ids = null)
        {
            return this.context.FindFolders(parentFolderID, search, pageIndex, pageSize, orderBy);
        }

        public Task<Folder> Get(long id)
        {
            return this.context.GetFolder(id);
        }

    }
}
