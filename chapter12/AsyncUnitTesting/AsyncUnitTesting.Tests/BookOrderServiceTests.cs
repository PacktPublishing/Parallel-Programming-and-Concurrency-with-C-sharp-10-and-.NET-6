namespace AsyncUnitTesting.Tests
{
    public class BookOrderServiceTests
    {
        [Fact]
        public void GetCustomerOrderNumbers_Returns_Orders_For_Valid_CustomerId_Sync()
        {
            var service = new BookOrderService();
            List<string> orders = service.GetCustomerOrderNumbers(5).GetAwaiter().GetResult();

            Assert.NotNull(orders);
            Assert.True(orders.Any());
            Assert.StartsWith("5", orders[0]);
        }

        [Fact]
        public async Task GetCustomerOrderNumbers_Returns_Orders_For_Valid_CustomerId()
        {
            var service = new BookOrderService();
            var orders = await service.GetCustomerOrderNumbers(3);

            Assert.NotNull(orders);
            Assert.True(orders.Any());
            Assert.StartsWith("3", orders[0]);
        }

        [Fact]
        public async Task GetCustomerOrderNumbers_Throws_Exception_For_Invalid_CustomerId()
        {
            var service = new BookOrderService();
            await Assert.ThrowsAsync<ArgumentException>(async () => await service.GetCustomerOrderNumbers(-2));
        }
    }
}