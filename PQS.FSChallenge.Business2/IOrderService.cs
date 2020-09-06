using System;
using System.Collections.Generic;
using System.Text;

namespace PQS.FSChallenge.Business
{
    public interface IOrderService
    {
        ICollection<OrdersInfo> GetOrders(OrderStatus status);
        Orders GetOrderById(int orderId);
        void ApproveOrder(int orderId);
        void RejectOrder(int orderId);
    }
}
