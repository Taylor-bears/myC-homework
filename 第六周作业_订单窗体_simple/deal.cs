using System;
using System.Collections.Generic;
using System.Linq;

namespace 订单管理
{
    public class OrderDetails
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is OrderDetails details)
            {
                return ProductName == details.ProductName && Quantity == details.Quantity && Price == details.Price;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductName, Quantity, Price);
        }

        public override string ToString()
        {
            return $"Product: {ProductName}, Quantity: {Quantity}, Price: {Price}";
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public List<OrderDetails> Details { get; set; } = new List<OrderDetails>();

        public decimal TotalAmount => Details.Sum(d => d.Quantity * d.Price);

        public override bool Equals(object obj)
        {
            if (obj is Order order)
            {
                return OrderId == order.OrderId && Customer == order.Customer && Details.SequenceEqual(order.Details);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OrderId, Customer, Details);
        }

        public override string ToString()
        {
            return $"Order ID: {OrderId}, Customer: {Customer}, Total Amount: {TotalAmount}\nDetails:\n{string.Join("\n", Details)}";
        }
    }

    public class OrderService
    {
        private List<Order> orders = new List<Order>();

        public void AddOrder(Order order)
        {
            if (orders.Contains(order))
            {
                throw new InvalidOperationException("Order already exists.");
            }
            orders.Add(order);
        }

        public void RemoveOrder(int orderId)
        {
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }
            orders.Remove(order);
        }

        // 修改订单的方法，改为操作订单明细
        public void UpdateOrder(int orderId, Action<Order> updateAction)
        {
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }
            updateAction(order); // 通过委托来执行具体的明细修改操作
        }

        // 辅助方法：添加订单明细
        public void AddOrderDetail(int orderId, OrderDetails detail)
        {
            UpdateOrder(orderId, order =>
            {
                if (order.Details.Any(d => d.ProductName == detail.ProductName))
                {
                    throw new InvalidOperationException($"Product '{detail.ProductName}' already exists in order.");
                }
                order.Details.Add(detail);
            });
        }

        // 辅助方法：删除订单明细
        public void RemoveOrderDetail(int orderId, string productName)
        {
            UpdateOrder(orderId, order =>
            {
                var detail = order.Details.FirstOrDefault(d => d.ProductName == productName);
                if (detail == null)
                {
                    throw new InvalidOperationException($"Product '{productName}' not found in order.");
                }
                order.Details.Remove(detail);
            });
        }

        // 辅助方法：修改订单明细
        public void ModifyOrderDetail(int orderId, string productName, Action<OrderDetails> modifyAction)
        {
            UpdateOrder(orderId, order =>
            {
                var detail = order.Details.FirstOrDefault(d => d.ProductName == productName);
                if (detail == null)
                {
                    throw new InvalidOperationException($"Product '{productName}' not found in order.");
                }
                modifyAction(detail); // 通过委托修改具体的明细属性
            });
        }

        public List<Order> QueryOrders(Func<Order, bool> predicate)
        {
            return orders.Where(predicate).OrderBy(o => o.TotalAmount).ToList();
        }

        public void SortOrders(Comparison<Order> comparison = null)
        {
            if (comparison == null)
            {
                orders.Sort((o1, o2) => o1.OrderId.CompareTo(o2.OrderId));
            }
            else
            {
                orders.Sort(comparison);
            }
        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }
    }
}