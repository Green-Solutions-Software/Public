using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Interfaces
{
    public interface IPagesRepository : IRepository<GS.PflanzenCMS.Rest.SDK.Models.Page, GS.PflanzenCMS.Rest.SDK.Models.Page.Summary>
    {
        Paginated<GS.PflanzenCMS.Rest.SDK.Models.Page.Summary> FindAll(long? parentId, string search, int pageIndex, int pageSize, string orderBy);
    }
}
