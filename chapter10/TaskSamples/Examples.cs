namespace TaskSamples
{
    public class Examples
    {
        public void ProcessOrders(List<Order> orders, int customerId)
        {
            Task<List<Order>> processOrdersTask = Task.Run(() => PrepareOrders(orders));
            Task labelTask = Task.Factory.StartNew(() => CreateLabels(orders), TaskCreationOptions.LongRunning);
            Task sendTask = processOrdersTask.ContinueWith(task => SendOrders(task.Result));

            Task.WaitAll(new[] { labelTask, sendTask });

            SendConfirmation(customerId);
        }

        public void ProcessData(object data, bool uiRequired)
        {
            Task processTask = new(() => DoDataProcessing(data));

            if (uiRequired)
            {
                // Run on current thread (UI thread assumed for example)
                processTask.RunSynchronously();
            }
            else
            {
                // Run on ThreadPool thread in background
                processTask.Start();
            }
        }

        private void DoDataProcessing(object data)
        {
            // TODO: Process the data
        }

        private List<Order> PrepareOrders(List<Order> orders)
        {
            // TODO: Prepare orders here
            return orders;
        }

        private void CreateLabels(List<Order> orders)
        {
            // TODO: Create labels here
        }

        private void SendOrders(List<Order> orders)
        {
            // TODO: Send orders here
        }

        private void SendConfirmation(int customerId)
        {
            // TODO: Send confirmation message to customer
        }
    }
}