using ConcurrentOrderQueue;
Console.WriteLine("Hello, World!");
var service = new OrderService();
await service.EnqueueOrders();
var orders = service.DequeueOrders();
foreach(var order in orders)
{
    Console.WriteLine(order.ItemName);
}