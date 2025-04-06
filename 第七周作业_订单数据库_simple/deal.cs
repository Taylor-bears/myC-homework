using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;

namespace 订单管理
{
    public class OrderDetails
    {
        public int OrderId { get; set; }  // 添加这个属性用于关联订单
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public override bool Equals(object obj)//上课讲的Equal，也就是自己定义等价判定
        {
            if (obj is OrderDetails details)
            {
                return ProductName == details.ProductName && Quantity == details.Quantity && Price == details.Price;
            }
            return false;
        }

        public override int GetHashCode()//就是将各个属性合并生成一个哈希码
        {
            return HashCode.Combine(ProductName, Quantity, Price);
        }

        public override string ToString()//课上也说到了
        {
            return $"Product: {ProductName}, Quantity: {Quantity}, Price: {Price}";
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public List<OrderDetails> Details { get; set; } = new List<OrderDetails>();

        [NotMapped]  // 表示这个属性不映射到数据库
        public decimal TotalAmount => Details.Sum(d => d.Quantity * d.Price);

        public override bool Equals(object obj)
        {
            if (obj is Order order)
            { //注意这里的列表比较方法
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
        private readonly OrderContext _context; // 数据库上下文,与数据库交互
   
        public OrderService(OrderContext context)
        {
            _context = context; // 初始化数据库上下文
        }
       
        // 添加订单
        public void AddOrder(Order order)
        {          
            if (_context.Orders.Any(o => o.OrderId == order.OrderId))
            {
                throw new InvalidOperationException("Order already exists."); // 订单已存在就抛异常
            }            
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
       
        // 删除订单       
        public void RemoveOrder(int orderId)
        {           
            var order = _context.Orders.Include(o => o.Details)
                              .FirstOrDefault(o => o.OrderId == orderId); // 先找订单
            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }          
            _context.Orders.Remove(order);           
            _context.SaveChanges();
        }

        // 更新订单      
        public void UpdateOrder(Order order)
        {          
            var existingOrder = _context.Orders.Include(o => o.Details)
                                     .FirstOrDefault(o => o.OrderId == order.OrderId);
            if (existingOrder == null)
            {
                throw new InvalidOperationException("Order not found.");
            }

            // 更新订单的属性
            // CurrentValues.SetValues将order对象的属性值复制到existingOrder
            _context.Entry(existingOrder).CurrentValues.SetValues(order);         

            // 删除在更新数据中不存在的明细
            foreach (var detail in existingOrder.Details.ToList()) // ToList()创建副本以避免修改集合时出错
            {
                // 如果现有明细在产品名称不在新订单的明细列表中，就删了
                if (!order.Details.Any(d => d.ProductName == detail.ProductName))
                {
                    _context.OrderDetails.Remove(detail);
                }
            }

            // 更新/添加明细
            foreach (var detail in order.Details)
            {
                // 查找有没有相同产品名称的明细
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
      
        // 查询订单       
        public List<Order> QueryOrders(Func<Order, bool> predicate)
        {
            return _context.Orders.Include(o => o.Details)
                         .Where(predicate)
                         .OrderBy(o => o.TotalAmount)
                         .ToList();
        }        
       
        // 获取所有订单     
        public List<Order> GetAllOrders()
        {           
            return _context.Orders.Include(o => o.Details).ToList();
        }
    }
}