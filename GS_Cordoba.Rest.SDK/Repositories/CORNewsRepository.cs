using GS.Cordoba.Rest.SDK.Classes;
using GS.Cordoba.Rest.SDK.Interfaces;
using GS.Cordoba.Rest.SDK.Models;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Repositories
{
    public class CORNewsRepository : Repository<News>, INewsRepository
    {
        public CORNewsRepository(Context context) : base(context)
        {
        }

        public Task<Paginated<News.Summary>> FindAll(string search, int pageIndex, int pageSize, string orderBy, long[] ids = null)
        {
            return this.context.FindNews(search, pageIndex, pageSize, orderBy);
        }

        public Task<News> Get(long id)
        {
            return this.context.GetNews(id);
        }

    }
}
