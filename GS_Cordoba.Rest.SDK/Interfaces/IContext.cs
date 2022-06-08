using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Interfaces
{
    public interface IContext
    {
        void InvalidateAll();
        void Invalidate(string key);
    }
}
