using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IAccountRepository
    {
        AccountInfo Info();
        string Validate(string username, string password);
        AccountInfo Login(string user, string password, int level = 0, bool automaticPasswordException = true);
    }
}
