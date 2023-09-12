using GS.Cordoba.Rest.SDK.Classes;
using GS.Cordoba.Rest.SDK.Interfaces;
using GS.Cordoba.Rest.SDK.Models;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Repositories
{
    public class CORFormatsRepository : Repository<Format>, IFormatsRepository
    {
        public CORFormatsRepository(Context context) : base(context)
        {
        }

        public Task<Paginated<Format.Summary>> FindAll(string search, int pageIndex, int pageSize, string orderBy, long[] ids = null)
        {
            return this.context.FindFormats(search, pageIndex, pageSize, orderBy);
        }

        public Task<Format> Get(long id)
        {
            return this.context.GetFormat(id);
        }
    }
}
