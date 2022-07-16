namespace ConcurrentOrderQueue.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        public async Task EnqueueOrders_Creates_Orders_For_All_Customers()
        {
            var orderService = new OrderService();
            var orderNumbers = new List<int> { 2, 5, 9 };
            await orderService.EnqueueOrders(orderNumbers);
            var orders = orderService.DequeueOrders();
            Assert.NotNull(orders);
            Assert.True(orders.Any());
            Assert.Contains(orders, o => o.CustomerId == 2);
            Assert.Contains(orders, o => o.CustomerId == 5);
            Assert.Contains(orders, o => o.CustomerId == 9);
        }

        [Fact]
        public void EnqueueOrders_Creates_Orders_For_All_Customers_SpinWait()
        {
            var orderService = new OrderService();
            var orderNumbers = new List<int> { 2, 5, 9 };
            orderService.EnqueueOrdersSync(orderNumbers);
            SpinWait.SpinUntil(() => orderService.EnqueueCount == orderNumbers.Count);
            var orders = orderService.DequeueOrders();
            Assert.NotNull(orders);
            Assert.True(orders.Any());
            Assert.Contains(orders, o => o.CustomerId == 2);
            Assert.Contains(orders, o => o.CustomerId == 5);
            Assert.Contains(orders, o => o.CustomerId == 9);
        }
    }
}