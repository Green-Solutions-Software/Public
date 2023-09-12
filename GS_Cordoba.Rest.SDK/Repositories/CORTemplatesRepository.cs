using GS.Cordoba.Rest.SDK.Classes;
using GS.Cordoba.Rest.SDK.Interfaces;
using GS.Cordoba.Rest.SDK.Models;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Repositories
{
    public class CORTemplatesRepository : Repository<Template>, ITemplatesRepository
    {
        public CORTemplatesRepository(Context context) : base(context)
        {
        }

        public Task<Paginated<Template.Summary>> FindAll(string search, int pageIndex, int pageSize, string orderBy, long[] ids = null)
        {
            return this.context.FindTemplates(search, pageIndex, pageSize, orderBy);
        }

        public Task<Template> Get(long id)
        {
            return this.context.GetTemplate(id);
        }
    }
}
