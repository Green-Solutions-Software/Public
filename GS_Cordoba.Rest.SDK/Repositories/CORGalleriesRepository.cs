using GS.Cordoba.Rest.SDK.Classes;
using GS.Cordoba.Rest.SDK.Interfaces;
using GS.Cordoba.Rest.SDK.Models;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Repositories
{
    public class CORGalleriesRepository : Repository<Gallery>, IGalleriesRepository
    {
        public CORGalleriesRepository(Context context) : base(context)
        {
        }

        public Task<Paginated<Gallery.Summary>> FindAll(string search, int pageIndex, int pageSize, string orderBy, long[] ids = null)
        {
            return this.context.FindGalleries(search, pageIndex, pageSize, orderBy);
        }

        public Task<Gallery> Get(long id)
        {
            return this.context.GetGallery(id);
        }

        public Task<Gallery> Get(string key)
        {
            return this.context.GetGalleryByKey(key);
        }

    }
}
