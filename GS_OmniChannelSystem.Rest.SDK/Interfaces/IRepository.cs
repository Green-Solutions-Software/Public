using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.OmniChannelSystem.Rest.SDK.Models;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IRepository
    {
    }

    public interface IRepository<T> : IRepository
        where T : GS.OmniChannelSystem.Rest.SDK.Models.Entity
    {
        T Get(long id, string[] properties = null);
        U Get<U>(long id, string[] properties = null) where U : T, new();
        T Get(string external_key, string[] properties = null);
        List<T> Get(long[] id, string[] properties = null);
        List<U> Get<U>(long[] id, string[] properties = null) where U : T, new();
        void Delete(long id, bool permanent = false);
        T Get(EntityReference reference);
        T Update(long id, T entity, string[] properties = null);
    }

    public interface IRepository<T, S> : IRepository<T>
        where T : GS.OmniChannelSystem.Rest.SDK.Models.Entity
        where S : GS.OmniChannelSystem.Rest.SDK.Models.Summary
    {
        Paginated<S> FindAll(string search, int pageIndex, int pageSize, string orderBy, string filter = null, string ids = null);
        S Create(T entity);

    }

    public interface IFilteredRepository<T, S, F> : IRepository<T,S>
        where T : GS.OmniChannelSystem.Rest.SDK.Models.Entity
        where S : GS.OmniChannelSystem.Rest.SDK.Models.Summary
        where F : GS.OmniChannelSystem.Rest.SDK.Filters.Base
    {
        Paginated<S> FindAll(string search, int pageIndex, int pageSize, string orderBy, F filter = null, long[] ids = null);
    }
}
