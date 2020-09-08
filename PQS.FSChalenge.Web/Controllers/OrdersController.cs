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
        [HttpGet("api/[controller]/{id}")]
        public ActionResult<Orders> GetOrderbyId(int id)
        {
            IOrderService orderService = new OrderService();
            
            return orderService.GetOrderById(id);
        }

        [HttpGet("api/[controller]/pending")]
        public ICollection<OrdersInfo> GetPendingOrders()
        {
            IOrderService orderService = new OrderService();

            return orderService.GetOrders(OrderStatus.Pending);
        }

        [HttpGet("api/[controller]/approved")]
        public ICollection<OrdersInfo> GetApprovedOrders()
        {
            IOrderService orderService = new OrderService();

            return orderService.GetOrders(OrderStatus.Approved);
        }

        [HttpGet("api/[controller]/rejected")]
        public ICollection<OrdersInfo> GetRejectedOrders()
        {
            IOrderService orderService = new OrderService();

            return orderService.GetOrders(OrderStatus.Rejected);
        }

        //POST api/<OrdersController>
        [HttpPost("api/[controller]/{id}")]
        public void ApproveOrder(int orderId)
        {
            IOrderService orderService = new OrderService();

            orderService.ApproveOrder(orderId);
        }

        [HttpDelete("api/[controller]/{id}")]
        public void RejectOrder(int orderId)
        {
            IOrderService orderService = new OrderService();

            orderService.RejectOrder(orderId);
        }
    }
}
