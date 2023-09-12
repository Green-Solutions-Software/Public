using GS.Cordoba.Rest.SDK.Models;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Interfaces
{
    public interface IGalleriesRepository : IRepository<Gallery, Gallery.Summary>
    {
        Task<Gallery> Get(string key);
    }
}
