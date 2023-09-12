using GS.Cordoba.Rest.SDK.Classes;
using GS.Cordoba.Rest.SDK.Interfaces;
using GS.Cordoba.Rest.SDK.Models;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Repositories
{
    public class CORPlantPicturesRepository : Repository<PlantPicture>, IPlantPicturesRepository
    {
        public CORPlantPicturesRepository(Context context) : base(context)
        {
        }

        public Task<Paginated<PlantPicture.Summary>> FindAll(string search, int pageIndex, int pageSize, string orderBy, long[] ids = null)
        {
            return this.context.FindPlantPictures(search, pageIndex, pageSize, orderBy);
        }

        public Task<PlantPicture> Get(long id)
        {
            return this.context.GetPlantPicture(id);
        }
    }
}
