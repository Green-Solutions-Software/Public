using GS.Cordoba.Rest.SDK.Classes;
using GS.Cordoba.Rest.SDK.Interfaces;
using GS.Cordoba.Rest.SDK.Models;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Repositories
{
    public class CORVideosRepository : Repository<Video>, IVideosRepository
    {
        public CORVideosRepository(Context context) : base(context)
        {
        }

        public Task<Paginated<Video.Summary>> FindAll(string search, int pageIndex, int pageSize, string orderBy, long[] ids = null)
        {
            return this.context.FindVideos(search, pageIndex, pageSize, orderBy);
        }

        public Task<Video> Get(long id)
        {
            return this.context.GetVideo(id);
        }
    }
}
