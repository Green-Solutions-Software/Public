using GS.Cordoba.Rest.SDK.Interfaces;
using GS.Cordoba.Rest.SDK.Models;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Repositories
{
    public class CORMailingsRepository : Repository, IMailingsRepository
    {
        public CORMailingsRepository(Context context) : base(context)
        {
        }

        public Task MemberMessage(long id, MemberMessageArgs args)
        {
            return this.context.MemberMessage(id, args);
        }

    }
}
