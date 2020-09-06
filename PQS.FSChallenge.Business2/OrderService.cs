using Microsoft.EntityFrameworkCore;
using PQS.FSChallenge.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PQS.FSChallenge.Business
{
    public class OrderService : IOrderService
    {
        private PQSChallengeContext _context;
        public OrderService()
        {
            var connectionstring = "Data Source=DESKTOP-SM8SANU\\SQLEXPRESS;Initial Catalog =PQS Challenge;Integrated Security=True";

            var optionsBuilder = new DbContextOptionsBuilder<PQSChallengeContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            _context = new PQSChallengeContext(optionsBuilder.Options);
        }

        public void ApproveOrder(int orderId)
        {
            try
            {
                var order = _context.Orders.Find(orderId);
                if (order.OrderStatus.Equals(OrderStatus.Pending))
                {
                    order.OrderStatus = OrderStatus.Approved;
                    order.AuthDate = DateTime.Now;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //HANDLE EXCEPTION
                throw ex;
            }
        }

        public Orders GetOrderById(int orderId)
        {
            try 
            { 
                var order = _context.Orders.Find(orderId);
                _context.Entry(order).Collection(o => o.OrderItems).Load();

                return order;
            }
            catch (Exception ex)
            {
                //HANDLE EXCEPTION
                throw ex;
            }
        }

        public ICollection<OrdersInfo> GetOrders(OrderStatus status)
        {
            try
            {
                return _context.OrdersInfo.Where(oi => oi.OrderStatus.Equals(status)).ToList();
            }
            catch (Exception ex)
            {
                //HANDLE EXCEPTION
                throw ex;
            }
        }

        public void RejectOrder(int orderId)
        {
            try
            {
                var order = _context.Orders.Find(orderId);
                if (order.OrderStatus.Equals(OrderStatus.Pending))
                {
                    order.OrderStatus = OrderStatus.Rejected;
                    order.AuthDate = DateTime.Now;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //HANDLE EXCEPTION
                throw ex;
            }
        }
    }
}
