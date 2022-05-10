using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class MessagesRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Message, GS.OmniChannelSystem.Rest.SDK.Models.Message.Summary>, IMessagesRepository
    {
        public MessagesRepository(Context context)
            :base(context,"api/messages")
        {
            
        }

        public Message Submit(Message message)
        {
            return this.context.SubmitMessage(message);
        }

        public List<Workflow> GetWorkflow(long messageId)
        {
            return this.context.GetMessageWorkflow(messageId);
        }

        public Message ExecuteWorkflow(long messageId, Workflow workflow)
        {
            return this.context.ExecuteMessageWorkflow(messageId, workflow);
        }

        public Paginated<GS.OmniChannelSystem.Rest.SDK.Models.Message> GetForOrder(long orderId, string search, int pageIndex, int pageSize, string orderBy, string filter = null)
        {
            return this.context.FindAll<GS.OmniChannelSystem.Rest.SDK.Models.Message>(this.resource + "/order/" + orderId, search, pageIndex, pageSize, orderBy, filter);
        }

    }
}