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
    public class CORLanguagesRepository : Repository<Language>, ILanguagesRepository
    {
        public CORLanguagesRepository(Context context) : base(context)
        {
        }

        public Task<Paginated<Language.Summary>> FindAll(string search, int pageIndex, int pageSize, string orderBy, long[] ids = null)
        {
            return this.context.FindLanguages(search, pageIndex, pageSize, orderBy);
        }

        public Task<Language> Get(long id)
        {
            return this.context.GetLanguage(id);
        }
    }
}
