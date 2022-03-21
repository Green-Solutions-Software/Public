using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IReportsRepository : IRepository<GS.OmniChannelSystem.Rest.SDK.Models.Report, GS.OmniChannelSystem.Rest.SDK.Models.Report.Summary>
    {
    }
}
