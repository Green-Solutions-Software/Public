﻿using GS.OmniChannelSystem.Rest.SDK.Models;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
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