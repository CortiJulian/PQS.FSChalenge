using System;
using System.Collections.Generic;

namespace PQS.FSChallenge.Business
{
    public partial class OrdersInfo
    {
        public int OrderId { get; set; }
        public string OrderDescription { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? AuthDate { get; set; }
        public decimal? Total { get; set; }
        public int? Qitems { get; set; }
    }
}
