using System;
using System.Collections.Generic;

namespace PQS.FSChallenge.Business
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string OrderDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? AuthDate { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }

    public enum OrderStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = -1
    }
}
