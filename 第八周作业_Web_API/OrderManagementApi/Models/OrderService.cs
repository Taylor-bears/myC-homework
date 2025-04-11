using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace 订单管理
{
    public class OrderService
    {
        private readonly OrderContext _context;

        public OrderService(OrderContext context)
        {
            _context = context;
        }

        public void AddOrder(Order order)
        {
            if (_context.Orders.Any(o => o.OrderId == order.OrderId))
            {
                throw new InvalidOperationException("订单已存在。");
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void RemoveOrder(int orderId)
        {
            var order = _context.Orders.Include(o => o.Details)
                .FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                throw new InvalidOperationException("订单不存在。");
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = _context.Orders.Include(o => o.Details)
                .FirstOrDefault(o => o.OrderId == order.OrderId);
            if (existingOrder == null)
            {
                throw new InvalidOperationException("订单不存在。");
            }

            _context.Entry(existingOrder).CurrentValues.SetValues(order);

            foreach (var detail in existingOrder.Details.ToList())
            {
                if (!order.Details.Any(d => d.ProductName == detail.ProductName))
                {
                    _context.OrderDetails.Remove(detail);
                }
            }

            foreach (var detail in order.Details)
            {
                var existingDetail = existingOrder.Details
                    .FirstOrDefault(d => d.ProductName == detail.ProductName);
                if (existingDetail != null)
                {
                    _context.Entry(existingDetail).CurrentValues.SetValues(detail);
                }
                else
                {
                    existingOrder.Details.Add(detail);
                }
            }
            _context.SaveChanges();
        }

        public List<Order> QueryOrders(Func<Order, bool> predicate)
        {
            return _context.Orders.Include(o => o.Details)
                .Where(predicate)
                .OrderBy(o => o.TotalAmount)
                .ToList();
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.Include(o => o.Details).ToList();
        }
    }
}