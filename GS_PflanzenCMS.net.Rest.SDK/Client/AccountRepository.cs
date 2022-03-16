using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
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