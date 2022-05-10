using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IMessagesRepository : IRepository<GS.OmniChannelSystem.Rest.SDK.Models.Message, GS.OmniChannelSystem.Rest.SDK.Models.Message.Summary>
    {
        Message Submit(Message message);

        Paginated<GS.OmniChannelSystem.Rest.SDK.Models.Message> GetForOrder(long orderId, string search, int pageIndex, int pageSize, string orderBy, string filter = null);

        List<Workflow> GetWorkflow(long messageId);
        Message ExecuteWorkflow(long messageId, Workflow workflow);
    }
}
