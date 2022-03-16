using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Interfaces
{
    public interface IExtSourcesUnitOfWork
    {
        IUnitOfWork[] All { get; }
        IUnitOfWork this[string index] {get;}
        //IUnitOfWork this[long id] { get; }
    }
}
