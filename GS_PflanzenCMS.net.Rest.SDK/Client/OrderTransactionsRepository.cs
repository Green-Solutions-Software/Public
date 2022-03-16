﻿using GS.PflanzenCMS.Rest.SDK.Api.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GS.PflanzenCMS.Rest.SDK.Interfaces;
using GS.PflanzenCMS.Rest.SDK.Models;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class OrderTransactionsRepository : BaseRepository, IOrderTransactionsRepository
    {
        public OrderTransactionsRepository(Context context)
            :base(context)
        {

        }

        //public void UpdateStatus(OrderTransactionArgs args)
        //{
        //    this.context.UpdateOrderTransactionStatus(args);
        //}
        public void UpdateStatus(long id, OrderTransactionArgs args)
        {
            this.context.UpdateOrderTransactionStatus(id, args);
        }

        public Job UpdateStatusAsync(long id, OrderTransactionArgs args)
        {
            return this.context.UpdateOrderTransactionStatusAsync(id, args);
        }

        public T UpdateStatusAsync<T>(long id, OrderTransactionArgs args) where T : Job,new()
        {
            return this.context.UpdateOrderTransactionStatusAsync<T>(id, args);
        }

        

    }
}