using GS.Cordoba.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Interfaces
{
    public interface IAccountRepository
    {
        Task<string> Validate(string user, string password, int level = 0);
        Task<AccountInfo> Login(string user, string password, int level = 0);
        Task<AccountInfo> Info();
    }
}
