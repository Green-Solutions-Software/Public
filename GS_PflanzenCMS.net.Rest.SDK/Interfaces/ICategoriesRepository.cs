using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Interfaces
{
    public interface ICategoriesRepository : IRepository<GS.PflanzenCMS.Rest.SDK.Models.Category, GS.PflanzenCMS.Rest.SDK.Models.Category.Summary>
    {
    }
}
