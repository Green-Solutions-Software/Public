using GS.Cordoba.Rest.SDK.Classes;
using GS.Cordoba.Rest.SDK.Interfaces;
using GS.Cordoba.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Repositories
{
    public class CORMembersRepository : Repository<Member>, IMembersRepository
    {
        public CORMembersRepository(Context context) : base(context)
        {
        }

        public Task<Paginated<Member.Summary>> FindAll(string search, int pageIndex, int pageSize, string orderBy, long[] ids = null)
        {
            return this.context.FindMembers(search, pageIndex, pageSize, orderBy);
        }

        public Task<Paginated<Member.Summary>> FindAllActivated(string search, int pageIndex, int pageSize, string orderBy, long[] ids = null)
        {
            return this.context.FindMembersActivated(search, pageIndex, pageSize, orderBy, ids);
        }

        public Task<Member> Get(long id)
        {
            return this.context.GetMember(id);
        }
    }
}
