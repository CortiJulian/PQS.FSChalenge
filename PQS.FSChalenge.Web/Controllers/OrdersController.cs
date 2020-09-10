using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PQS.FSChallenge.Business;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PQS.FSChalenge.Web.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        /// <summary>
        /// Gets the specific order.
        /// </summary>
        /// <param name="orderId">The Id of the order to find.</param>   
        [HttpGet("api/[controller]/{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Orders> GetOrderbyId(int orderId)
        {
            IOrderService orderService = new OrderService();
            
            Orders order = orderService.GetOrderById(orderId);

            if (order != null)
                return Ok(order);
            else
                return NotFound();
        }

        /// <summary>
        /// Gets an OrderInfo list of orders pending of approval.
        /// </summary>
        [HttpGet("api/[controller]/pending")]
        public ActionResult<ICollection<OrdersInfo>> GetPendingOrders()
        {
            IOrderService orderService = new OrderService();

            ICollection<OrdersInfo> orders = orderService.GetOrders(OrderStatus.Pending);

            if (orders != null)
                return Ok(orders);
            else
                return NotFound();
        }

        /// <summary>
        /// Gets an OrderInfo list of approved orders.
        /// </summary>
        [HttpGet("api/[controller]/approved")]
        public ActionResult<ICollection<OrdersInfo>> GetApprovedOrders()
        {
            IOrderService orderService = new OrderService();

            ICollection<OrdersInfo> orders = orderService.GetOrders(OrderStatus.Approved);

            if (orders != null)
                return Ok(orders);
            else
                return NotFound();
        }

        /// <summary>
        /// Gets an OrderInfo list of rejected orders.
        /// </summary>
        [HttpGet("api/[controller]/rejected")]
        public ActionResult<ICollection<OrdersInfo>> GetRejectedOrders()
        {
            IOrderService orderService = new OrderService();

            ICollection<OrdersInfo> orders = orderService.GetOrders(OrderStatus.Rejected);

            if (orders != null)
                return Ok(orders);
            else
                return NotFound();
        }

        /// <summary>
        /// Approves the specific order.
        /// </summary>
        /// <param name="orderId">The Id of the order to approve.</param>
        [HttpPost("api/[controller]/{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ApproveOrder(int orderId)
        {
            IOrderService orderService = new OrderService();

            Orders order = orderService.GetOrderById(orderId);

            if (order != null)
            {
                if (orderService.ApproveOrder(order))
                    return Ok();
                else
                    return BadRequest();
            }
            return NotFound();
        }

        /// <summary>
        /// Rejects the specific order.
        /// </summary>
        /// <param name="orderId">The Id of the order to reject.</param>   
        [HttpDelete("api/[controller]/{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RejectOrder(int orderId)
        {
            IOrderService orderService = new OrderService();

            Orders order = orderService.GetOrderById(orderId);

            if (order != null)
            { 
                if (orderService.RejectOrder(order))
                    return Ok();
                else
                    return BadRequest();
            }
            return NotFound();
        }
    }
}
