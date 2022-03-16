using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Interfaces
{
    public interface IRightsRepository : IRepository<GS.PflanzenCMS.Rest.SDK.Models.Right, GS.PflanzenCMS.Rest.SDK.Models.Right.Summary>
    {
    }
}
