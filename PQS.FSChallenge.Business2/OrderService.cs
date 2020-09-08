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
                { 
                    _context.Entry(order).Collection(o => o.OrderItems).Load();

                    return order;
                }
                else
                {
                    throw ThrowError(HttpStatusCode.NotFound, string.Format("Order with Id={0} doesn't exist.", orderId));
                }
            }
            catch (Exception ex)
            {
                throw ThrowError(HttpStatusCode.BadRequest, ex.Message);
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
                throw ThrowError(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public void ApproveOrder(int orderId)
        {
            try
            {
                var order = _context.Orders.Find(orderId);

                if (order != null)
                {
                    if (order.OrderStatus.Equals(OrderStatus.Pending))
                    {
                        order.OrderStatus = OrderStatus.Approved;
                        order.AuthDate = DateTime.Now;
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw ThrowError(HttpStatusCode.BadRequest, string.Format("Order with Id={0} can't be approved.", orderId));
                    }
                }
                else
                {
                    throw ThrowError(HttpStatusCode.NotFound, string.Format("Order with Id={0} doesn't exist.", orderId));
                }
            }
            catch (Exception ex)
            {
                throw ThrowError(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public void RejectOrder(int orderId)
        {
            try
            {
                var order = _context.Orders.Find(orderId);

                if (order != null)
                {
                    if (order.OrderStatus.Equals(OrderStatus.Pending))
                    {
                        order.OrderStatus = OrderStatus.Rejected;
                        order.AuthDate = DateTime.Now;
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw ThrowError(HttpStatusCode.BadRequest, string.Format("Order with Id={0} can't be rejected.", orderId));
                    }
                }
                else
                {
                    throw ThrowError(HttpStatusCode.NotFound, string.Format("Order with Id={0} doesn't exist.", orderId));
                }
            }
            catch (Exception ex)
            {
                throw ThrowError(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        private HttpResponseException ThrowError(HttpStatusCode code, string message)
        {
            var response = new HttpResponseMessage(code)
            {
                Content = new StringContent(message, System.Text.Encoding.UTF8, "text/plain"),
                StatusCode = HttpStatusCode.NotFound
            };
            return new HttpResponseException(response);
        }
    }
}
