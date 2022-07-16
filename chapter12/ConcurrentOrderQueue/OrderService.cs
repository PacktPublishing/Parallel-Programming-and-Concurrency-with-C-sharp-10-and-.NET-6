using System.Collections.Concurrent;

namespace ConcurrentOrderQueue
{
    public class OrderService
    {
        private ConcurrentQueue<Order> _orderQueue = new();
        public int EnqueueCount = 0;
        public async Task EnqueueOrders()
        {
            await EnqueueOrders(new List<int> { 1, 2 });
        }

        public async Task EnqueueOrders(List<int> customerIds)
        {
            var tasks = new List<Task>();
            foreach (int id in customerIds)
            {
                tasks.Add(EnqueueOrders(id));
            }
            await Task.WhenAll(tasks);
        }

        public void EnqueueOrdersSync(List<int> customerIds)
        {
            EnqueueCount = 0;
            var tasks = new List<Task>();
            foreach (int id in customerIds)
            {
                tasks.Add(EnqueueOrders(id));
            }
        }

        private async Task EnqueueOrders(int customerId)
        {
            for (int i = 1; i < 6; i++)
            {
                var order = new Order
                {
                    Id = i * customerId,
                    CustomerId = customerId,
                    ItemName = "Widget for customer " + customerId,
                    ItemQty = 20 - (i * customerId)
                };
                order.OrderTotal = order.ItemQty * 5;
                _orderQueue.Enqueue(order);
                await Task.Delay(100 * customerId);
            }
            EnqueueCount++;
        }

        public List<Order> DequeueOrders()
        {
            List<Order> orders = new();

            while (_orderQueue.TryDequeue(out var order))
            {
                orders.Add(order);
            }

            return orders;
        }
    }
}