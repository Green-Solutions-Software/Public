using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using GS.PflanzenCMS.Rest.SDK.Models;
using GS.PflanzenCMS.Rest.SDK.Interfaces;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class DocumentsRepository : BaseRepository, IDocumentsRepository
    {
        public DocumentsRepository(Context context)
            :base(context)
        {
            
        }

        public string GetForOrder(long orderId, DocumentationType type)
        {
            return context.GetDocumentForOrder(orderId, type);
        }

        public string GetForOrders(long[] orderId, DocumentationType type)
        {
            return context.GetDocumentForOrders(orderId, type);
        }

        public string GetForOrder(long orderId, long orderTransactionId, DocumentationType type)
        {
            return context.GetDocumentForOrder(orderId, orderTransactionId, type);
        }

        

    }
}