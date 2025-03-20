using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace 订单管理
{
    public class OrderDetails
    {
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
        private List<Order> orders = new List<Order>();

        public void AddOrder(Order order)
        {
            if (orders.Contains(order))//有了要抛异常
            {
                throw new InvalidOperationException("Order already exists.");
            }
            orders.Add(order);
        }

        public void RemoveOrder(int orderId)
        {//注意我们寻找order用的就是它的ID，所以只需要比对ID
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)//没有找到也要抛
            {
                throw new InvalidOperationException("Order not found.");
            }
            orders.Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = orders.FirstOrDefault(o => o.OrderId == order.OrderId);
            if (existingOrder == null)
            {
                throw new InvalidOperationException("Order not found.");
            }
            orders.Remove(existingOrder);
            orders.Add(order);
        }

        public List<Order> QueryOrders(Func<Order, bool> predicate)
        {//这个用法很高明，有多个查询订单的方法，我们直接抽象为一个委托
            //用传入的委托过滤，排序，再输出
            return orders.Where(predicate).OrderBy(o => o.TotalAmount).ToList();
        }

        public void SortOrders(Comparison<Order> comparison = null)
        {
            //默认按订单号，有自定λ也可
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

    internal class Program
    {
        static void Main(string[] args)
        {
            OrderService service = new OrderService();

            // 添加订单
            Order order1 = new Order { OrderId = 1, Customer = "Taylor Swift" };
            order1.Details.Add(new OrderDetails { ProductName = "Midnights", Quantity = 10, Price = 100 });
            service.AddOrder(order1);

            Order order2 = new Order { OrderId = 2, Customer = "Ariana Grande" };
            order2.Details.Add(new OrderDetails { ProductName = "Eternal Sunshine", Quantity = 7, Price = 210 });
            service.AddOrder(order2);

            // 查询订单
            Console.WriteLine("Querying orders by customer ->");
            var queryResult = service.QueryOrders(o => o.Customer == "Taylor Swift");
            foreach (var order in queryResult)
            {
                Console.WriteLine(order);
                Console.WriteLine();
            }
            Console.WriteLine();

            // 修改订单（这里我们加到Taylor Swift的订单奥）
            order1.Details.Add(new OrderDetails { ProductName = "Lover", Quantity = 7, Price = 120 });
            service.UpdateOrder(order1);

            // 排序订单（这里我们用总额排，所以前面我专门设计A妹的总额低一些，符合第一个显示）
            Console.WriteLine("sorting orders by total amount ->");
            service.SortOrders((o1, o2) => o1.TotalAmount.CompareTo(o2.TotalAmount));
            var allOrders = service.GetAllOrders();
            foreach (var order in allOrders)
            {
                Console.WriteLine(order);
                Console.WriteLine();
            }
            Console.WriteLine();

            // 删除A妹的订单
            service.RemoveOrder(2);

            Console.WriteLine("After removing Ariana Grande's order ->");
            allOrders = service.GetAllOrders();
            foreach (var order in allOrders)
            {
                Console.WriteLine(order);
                Console.WriteLine();
            }
        }
    }
}
