using GS.Cordoba.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Interfaces
{
    public interface IGalleriesRepository : IRepository<Gallery, Gallery.Summary>
    {
        Task<Gallery> Get(string key);
    }
}
