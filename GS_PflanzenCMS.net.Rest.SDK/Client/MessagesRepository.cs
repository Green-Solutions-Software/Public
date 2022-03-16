using GS.PflanzenCMS.Rest.SDK.Api.Args;
using GS.PflanzenCMS.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class MessagesRepository : BaseRepository<GS.PflanzenCMS.Rest.SDK.Models.Message, GS.PflanzenCMS.Rest.SDK.Models.Message.Summary>, IMessagesRepository
    {
        public MessagesRepository(Context context)
            :base(context,"api/messages")
        {
            
        }

        public Message Submit(Message message)
        {
            return this.context.SubmitMessage(message);
        }

    }
}