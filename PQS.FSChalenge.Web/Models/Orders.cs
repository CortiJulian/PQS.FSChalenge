using System;
using System.Collections.Generic;

namespace PQS.FSChalenge.Web.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int OrderId { get; set; }
        public int OrderStatus { get; set; }
        public string OrderDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? AuthDate { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
