using Microsoft.EntityFrameworkCore;
using PQS.FSChallenge.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

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

        public Orders GetOrderById(int orderId)
        {
            try
            {
                var order = _context.Orders.Find(orderId);

                if(order != null)
                    _context.Entry(order).Collection(o => o.OrderItems).Load();

                return order;
            }
            catch (Exception ex)
            {
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
                throw ex;
            }
        }

        public bool ApproveOrder(Orders order)
        {
            try
            {
                if (order.OrderStatus.Equals(OrderStatus.Pending))
                {
                    order.OrderStatus = OrderStatus.Approved;
                    order.AuthDate = DateTime.Now;
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RejectOrder(Orders order)
        {
            try
            {
                if (order.OrderStatus.Equals(OrderStatus.Pending))
                {
                    order.OrderStatus = OrderStatus.Rejected;
                    order.AuthDate = DateTime.Now;
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
