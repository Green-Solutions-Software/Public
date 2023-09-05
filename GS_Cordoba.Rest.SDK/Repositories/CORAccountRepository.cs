using GS.Cordoba.Rest.SDK.Interfaces;
using GS.Cordoba.Rest.SDK.Models;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Repositories
{
    public class CORAccountRepository : Repository, IAccountRepository
    {
        public CORAccountRepository(Context context) : base(context)
        {
        }

        public Task<string> Validate(string user, string password, int level = 0)
        {
            return this.context.ValidateAccount(user, password, level);
        }

        public Task<AccountInfo> Login(string user, string password, int level = 0)
        {
            return this.context.LoginAccount(user, password, level);
        }

        public Task<AccountInfo> Info()
        {
            return this.context.AccountInfo();
        }

        


    }
}
