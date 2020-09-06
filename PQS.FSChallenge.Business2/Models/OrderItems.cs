using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PQS.FSChallenge.Business
{
    public partial class OrderItems
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        [JsonIgnore]
        public virtual Orders Order { get; set; }
    }
}
