using GS.Cordoba.Rest.SDK.Classes;
using GS.Cordoba.Rest.SDK.Interfaces;
using GS.Cordoba.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Repositories
{
    public class CORPlantsRepository : Repository<Plant>, IPlantsRepository
    {
        public CORPlantsRepository(Context context) : base(context)
        {
        }

        public Task<Paginated<Article.Summary>> FindAll(string search, int pageIndex, int pageSize, string orderBy, long[] ids = null)
        {
            return this.context.FindPlants(search, pageIndex, pageSize, orderBy);
        }

        public Task<Plant> Get(long id)
        {
            return this.context.GetPlant(id);
        }
    }
}
