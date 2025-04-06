using 订单管理;

internal class Program
{
    static void Main(string[] args)
    {      
        using var context = new OrderContext(); // 创建数据库上下文

        // 每次启动时清空并重建数据库
        context.Database.EnsureDeleted(); // 删除
        context.Database.EnsureCreated(); // 创建
        // 这里我这样处理的原因在于我发现它运行一遍后第二遍会出错，应该是数据反复添加抛异常，所以这里我这样设定

        context.Database.EnsureCreated(); //确保数据库已创建，之前这里报错是因为版本的不兼容，我更换了包的版本就好了

        var service = new OrderService(context);

        // 添加订单
        Order order1 = new Order { OrderId = 1, Customer = "Taylor Swift" };
        order1.Details.Add(new OrderDetails
        {
            OrderId = 1,
            ProductName = "Midnights",
            Quantity = 10,
            Price = 100
        });
        service.AddOrder(order1);

        Order order2 = new Order { OrderId = 2, Customer = "Ariana Grande" };
        order2.Details.Add(new OrderDetails
        {
            OrderId = 2,
            ProductName = "Eternal Sunshine",
            Quantity = 7,
            Price = 210
        });
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

        // 修改订单
        order1.Details.Add(new OrderDetails
        {
            OrderId = 1,
            ProductName = "Lover",
            Quantity = 7,
            Price = 120
        });
        service.UpdateOrder(order1);

        // 查询所有订单并按总金额排序
        Console.WriteLine("All orders sorted by total amount ->");
        var allOrders = service.GetAllOrders()
            .OrderBy(o => o.Details.Sum(d => d.Quantity * d.Price))
            .ToList();
        foreach (var order in allOrders)
        {
            Console.WriteLine(order);
            Console.WriteLine();
        }
        Console.WriteLine();

        // 我试过两次，第一次是删了的没问题，第二次不删，就有两个人
        // 删除订单
        //service.RemoveOrder(2);

        //Console.WriteLine("After removing Ariana Grande's order ->");
        //allOrders = service.GetAllOrders();
        //foreach (var order in allOrders)
        //{
        //    Console.WriteLine(order);
        //    Console.WriteLine();
        //}
    }
}