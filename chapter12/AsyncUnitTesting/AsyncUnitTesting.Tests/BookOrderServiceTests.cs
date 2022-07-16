namespace AsyncUnitTesting.Tests
{
    public class BookOrderServiceTests
    {
        [Fact]
        public void GetCustomerOrdersAsync_Returns_Orders_For_Valid_CustomerId_Sync()
        {
            var service = new BookOrderService();
            int customerId = 5;
            List<string> orders = service.GetCustomerOrdersAsync(customerId).GetAwaiter().GetResult();

            Assert.NotNull(orders);
            Assert.True(orders.Any());
            Assert.StartsWith(customerId.ToString(), orders[0]);
        }

        [Fact]
        public async Task GetCustomerOrdersAsync_Returns_Orders_For_Valid_CustomerId()
        {
            var service = new BookOrderService();
            int customerId = 3;
            var orders = await service.GetCustomerOrdersAsync(customerId);

            Assert.NotNull(orders);
            Assert.True(orders.Any());
            Assert.StartsWith(customerId.ToString(), orders[0]);
        }

        [Fact]
        public async Task GetCustomerOrdersAsync_Throws_Exception_For_Invalid_CustomerId()
        {
            var service = new BookOrderService();
            await Assert.ThrowsAsync<ArgumentException>(async () => await service.GetCustomerOrdersAsync(-2));
        }
    }
}