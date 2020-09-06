using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PQS.FSChallenge.Business;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PQS.FSChalenge.Web.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: api/<OrdersController>
        [HttpGet("[controller]/[action]/{orderId}")]
        public ActionResult<Orders> GetOrderbyId(int orderId)
        {
            IOrderService orderService = new OrderService();
            
            return orderService.GetOrderById(orderId);
        }

        [HttpGet("[controller]/[action]/{status}")]
        public ICollection<OrdersInfo> GetOrders(OrderStatus status)
        {
            IOrderService orderService = new OrderService();

            return orderService.GetOrders(status);
        }

        //POST api/<OrdersController>
        [HttpPost("[controller]/[action]/{orderId}")]
        public void ApproveOrder(int orderId)
        {
            IOrderService orderService = new OrderService();

            orderService.ApproveOrder(orderId);
        }
    }
}
