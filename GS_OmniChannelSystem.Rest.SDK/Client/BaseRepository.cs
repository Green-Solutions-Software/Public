using GS.OmniChannelSystem.Rest.SDK.Interfaces;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class BaseRepository
    {
        protected Context context = null;

        public BaseRepository(Context context)
        {
            this.context = context;
        }
    }

    public abstract class BaseRepository<T,S>:BaseRepository 
        where T : GS.OmniChannelSystem.Rest.SDK.Models.Entity, new()
        where S : GS.OmniChannelSystem.Rest.SDK.Models.Summary, new()
    {
        protected string resource = null;

        public BaseRepository(Context context, string resource)
            :base(context)
        {
            this.resource = resource;
        }

        public T Get(EntityReference reference)
        {
            if (reference.ID > 0)
                return Get(reference.ID);

            throw new NotSupportedException();
        }

        public virtual List<T> Get(long[] ids, string[] properties = null)
        {
            if (!ids.Any())
                return new List<T>();

            return this.context.Get<List<T>>(this.resource + "/{id}", ids, properties);
        }

        public virtual List<U> Get<U>(long[] ids, string[] properties = null) where U:T, new()
        {
            if (!ids.Any())
                return new List<U>();

            return this.context.Get<List<U>>(this.resource + "/{id}", ids, properties);
        }

        public virtual Paginated<S> FindAll(string search, int pageIndex, int pageSize, string orderBy, string filter = null, string ids = null)
        {
            return this.context.FindAll<S>(this.resource, search, pageIndex, pageSize, orderBy, filter, ids);
        }

        public virtual T Get(long id, string[] properties = null)
        {
            return this.context.Get<T>(this.resource+"/{id}",id, properties);
        }

        public virtual U Get<U>(long id, string[] properties = null) where U:T,new()
        {
            return this.context.Get<U>(this.resource + "/{id}", id, properties);
        }

        public virtual T Get(string external_key, string[] properties = null)
        {
            return this.context.Get<T>(this.resource + "?ext=" + HttpUtility.UrlEncode(external_key), properties);
        }

        public virtual T Update(long id, T entity, string[] properties = null)
        {
            return this.context.Put<T>(this.resource + "/{id}", id, entity, properties);
        }

        public virtual S Create(T entity)
        {
            return this.context.Post<T,S>(this.resource, entity);
        }

        public virtual U Create<U>(T entity) where U:class, new()
        {
            return this.context.Post<T, S, U>(this.resource, entity);
        }

        public virtual void Delete(long id, bool permanent = false)
        {
            this.context.Delete<T>(this.resource + "/{id}", id, permanent);
        }
    }
}

