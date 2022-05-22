using System.Collections.Concurrent;

namespace ConcurrentOrderQueue
{
    public class OrderService
    {
        private ConcurrentQueue<Order> _orderQueue = new();
        public async Task EnqueueOrders()
        {
            var t1 = EnqueueOrders(1);
            var t2 = EnqueueOrders(2);

            await Task.WhenAll(t1, t2);
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