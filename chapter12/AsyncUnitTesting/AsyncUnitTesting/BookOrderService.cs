namespace AsyncUnitTesting
{
    public class BookOrderService
    {
        public async Task<List<string>> GetCustomerOrdersAsync(int customerId)
        {
            if (customerId < 1)
            {
                throw new ArgumentException("Customer ID must be greater than zero.", nameof(customerId));
            }

            var orders = new List<string>
            {
                customerId + "1",
                customerId + "2",
                customerId + "3",
                customerId + "4",
                customerId + "5",
                customerId + "6"
            };

            // Simulate time to fetch orders
            await Task.Delay(1500);

            return orders;
        }
    }
}