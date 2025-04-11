using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using 订单管理;

namespace OrderManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // 获取所有订单
        [HttpGet]
        public ActionResult<List<Order>> GetAllOrders()
        {
            try
            {
                var orders = _orderService.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"服务器错误: {ex.Message}");
            }
        }

        // 根据订单ID获取订单
        [HttpGet("{orderId}")]
        public ActionResult<Order> GetOrderById(int orderId)
        {
            try
            {
                var order = _orderService.GetAllOrders().FirstOrDefault(o => o.OrderId == orderId);
                if (order == null)
                {
                    return NotFound("订单不存在。");
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"服务器错误: {ex.Message}");
            }
        }

        // 添加订单
        [HttpPost]
        public ActionResult AddOrder([FromBody] Order order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _orderService.AddOrder(order);
                return CreatedAtAction(nameof(GetOrderById), new { orderId = order.OrderId }, order);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"服务器错误: {ex.Message}");
            }
        }

        // 更新订单
        [HttpPut("{orderId}")]
        public ActionResult UpdateOrder(int orderId, [FromBody] Order order)
        {
            try
            {
                if (orderId != order.OrderId)
                {
                    return BadRequest("订单ID不匹配。");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _orderService.UpdateOrder(order);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"服务器错误: {ex.Message}");
            }
        }

        // 删除订单
        [HttpDelete("{orderId}")]
        public ActionResult DeleteOrder(int orderId)
        {
            try
            {
                _orderService.RemoveOrder(orderId);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"服务器错误: {ex.Message}");
            }
        }

        // 查询订单（例如按客户名）
        [HttpGet("search")]
        public ActionResult<List<Order>> SearchOrders([FromQuery] string customer)
        {
            try
            {
                if (string.IsNullOrEmpty(customer))
                {
                    return BadRequest("客户名称不能为空。");
                }
                var orders = _orderService.QueryOrders(o => o.Customer.Contains(customer));
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"服务器错误: {ex.Message}");
            }
        }
    }
}