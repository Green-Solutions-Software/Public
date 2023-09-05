using GS.OmniChannelSystem.Rest.SDK.Models;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(Context context)
            :base(context)
        {
            
        }

        public AccountInfo Info()
        {
            return this.context.AccountInfo();
        }

        public string Validate(string username, string password)
        {
            return this.context.ValidateAccount(username, password);
        }

        public AccountInfo Login(string user, string password, int level = 0, bool automaticPasswordException = true)
        {
            return this.context.LoginAccount(user, password, level, automaticPasswordException);
        }
    }
}