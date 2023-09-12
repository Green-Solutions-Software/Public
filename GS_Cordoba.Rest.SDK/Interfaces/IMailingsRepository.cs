using GS.Cordoba.Rest.SDK.Models;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Interfaces
{
    public interface IMailingsRepository 
    {
        Task MemberMessage(long id, MemberMessageArgs args);
    }
}
