﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GS.OmniChannelSystem.Rest.SDK.Models
{
    public class WorkflowOrderItem
    {
        public long OrderItemID { get; set; }
        public int Quantity { get; set; }

        public WorkflowOrderItem()
        {

        }

        public WorkflowOrderItem(long orderItemID, int quantity)
        {
            this.OrderItemID = orderItemID;
            this.Quantity = quantity;
        }
    }

    public class Workflow
    {
        public Workflow()
        {
            this.Positions = new List<WorkflowOrderItem>();
        }

        public string Text { get; set; }
        public string Title { get; set; }
        public string Action { get; set; }
        public MessageType Type { get; set; }

        public bool Refund { get; set; }
        public bool Replacement { get; set; }
        public List<WorkflowOrderItem> Positions { get; set; }

    }
}
